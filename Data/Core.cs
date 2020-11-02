using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Json.Serialization;

using System.Collections.Generic;

using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;


namespace AirShare
{
    public static class Core
    {

        public static JsonSerializerOptions JsonOptions = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        public static string ToJSON<T>(T Obj)
        {
            return JsonSerializer.Serialize(Obj, JsonOptions);
        }
        public static T FromJSON<T>(string JSON)
        {
            return JsonSerializer.Deserialize<T>(JSON, JsonOptions);
        }

        public static void Log(string S)
        {
            System.Console.WriteLine($" >> {S}");
        }

        public static void LogErr(System.Exception ex)
        {
            System.Console.WriteLine(ErrorMsg(ex));
        }

        public static string ErrorMsg(Exception ex)
        {
            return $" !> {ex} {ex.Message} \n Stack : \n{ex.StackTrace} \n \n Inner [{ex.InnerException} {ex.InnerException?.Message} {ex.InnerException?.StackTrace} \n]";
        }


        static AuthDetails AD;

        public static void LoadAD()
        {
            if (AD == null)
            {
                if (!File.Exists("auth.json"))
                {
                    CreateDefaultAD();
                    SaveAD();
                }
                else
                {
                    string sA = File.ReadAllText("auth.json");
                    try
                    {
                        AD = FromJSON<AuthDetails>(sA);
                    }
                    catch (System.Exception)
                    {
                        CreateDefaultAD();
                        SaveAD();

                        Log("Password reset");
                    }

                }
            }
        }
        public static User Auth(string name, string pass)
        {

            LoadAD();

            if (name == null) return null;

            if (AD.Pars.TryGetValue(name, out User usr))
            {
                if (usr.HPass == HashStr(pass))
                {
                    UserTokens[usr.Token()] = usr;
                    return usr;
                }
            }


            return null;
        }

        static string AirSharedDir;
        public static string CreateAirSharedDir()
        {
            if (AirSharedDir == null)
            {
                try
                {
                    AirSharedDir = Directory.CreateDirectory("AirShared").FullName;
                    File.WriteAllText("AirShared/GuestShared.txt", "This directory is shared with guests. No passwords required");
                }
                catch (System.Exception)
                {
                    AirSharedDir = Directory.CreateDirectory("AirShared" + TempSecret()).FullName;
                    File.WriteAllText(Path.Combine(AirSharedDir, "/GuestShared.txt"), "This directory is shared with guests. No passwords required");

                }
            }
            return AirSharedDir;
        }



        static readonly Dictionary<string, User> UserTokens = new Dictionary<string, User>();

        public static User AuthToken(string t)
        {
            if (t == null) return null;
            if (UserTokens.TryGetValue(t, out User usr))
            {
                return usr;
            }
            else
            {
                string[] ts = t.Split("^", 3);
                if (ts.Count() == 3)
                {
                    Auth(ts[0], ts[2]);
                    if (UserTokens.TryGetValue(t, out usr))
                    {
                        bool SOK = false;
                        for (int i = 0; i < 3; i++)
                        {
                            if (ts[1] == usr.Token(i))
                            {
                                SOK = true;
                                break;
                            }
                        }


                        if (SOK)
                        {
                            return usr;
                        }
                    }
                }
            }

            return null;
        }

        public static User AuthReq(Microsoft.AspNetCore.Http.HttpRequest Req, Microsoft.AspNetCore.Http.HttpResponse Resp)
        {
            if (Req.Cookies.TryGetValue("ut", out string token))
            {
                User usr = AuthToken(token);
                if (usr != null)
                {
                    Resp.Cookies.Append("ut", usr.Token());
                    return usr;
                }
            }
            return null;
        }



        public static IEnumerable<User> GetUsers()
        {
            LoadAD();
            return AD.Pars.Values;
        }

        public static void CreateDefaultAD()
        {
            AD = new AuthDetails()
            {
                Pars = new Dictionary<string, User>()
            {
                { "admin", new User()
                {Name = "admin", Allowed =  new List<string>(){"/" , "\\"}.ToArray(), Lvl = UserLevel.root, HPass = HashStr("pass") }
                } }
            };

        }
        public static void SaveAD()
        {
            File.WriteAllText("auth.json", ToJSON(AD));
        }

        public static bool ChangePass(string Name, string OldPass, string newPass)
        {
            User usr = Auth(Name, OldPass);
            if (usr == null)
            {
                return false;
            }

            usr.HPass = HashStr(newPass);
            SaveAD();

            return true;

        }

        public static string AddUser(string Name, string newPass, UserLevel lvl, string allowed)
        {
            LoadAD();

            string[] all = allowed.Split(Environment.NewLine);
            User usr = new User
            {
                Name = Name,
                Lvl = lvl,
                HPass = HashStr(newPass),
                Allowed = all
            };

            AD.Pars[usr.Name] = usr;
            SaveAD();

            return Core.ToJSON(usr);

        }





        static byte[] salt = null;
        public static string HashStr(string s)
        {
            if (salt == null)
            {
                salt = new byte[128 / 8];
                for (int i = 0; i < (128 / 8); i++)
                {
                    salt[i] = (byte)(((i * i) + 128 - i) | 255);
                }
            }


            byte[] keys = (KeyDerivation.Pbkdf2(
            password: s,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 1000,
            numBytesRequested: 128 / 8));

            return BitConverter.ToString(keys);

        }

        public static string TempSecret(int before = 0)
        {
            return DateTime.UtcNow.Date.AddMinutes((DateTime.UtcNow.Hour * 60) + (DateTime.UtcNow.Minute / 30) - (before * 30)).ToBinary().ToString();
        }



    }


    public class AuthDetails
    {
        public Dictionary<string, User> Pars { get; set; } = new Dictionary<string, User>();
    }
    public class User
    {
        public string Name { get; set; }
        public string HPass { get; set; }
        public string[] Allowed { get; set; }
        public UserLevel Lvl { get; set; }

        public string Token(int before = 0)
        {
            return Name + "^" + Core.HashStr(Core.TempSecret(before) + HPass) + "^" + HPass;
        }

        public bool Validate(string path)
        {
            if (Lvl == UserLevel.none) return false;
            if (Lvl == UserLevel.root) return true;

            if (Lvl >= UserLevel.guest)
            {
                if (path.StartsWith(Core.CreateAirSharedDir()))
                {
                    return true;
                }
            }

            if (Lvl == UserLevel.censored)
            {
                bool valid = false;
                foreach (string p in Allowed)
                {
                    if (path.StartsWith(p))
                    {
                        valid = true;
                        break;
                    }
                }
                return valid;
            }

            return false;
        }
    }

    public enum UserLevel
    {
        none,
        guest,
        censored,
        root

    }
}