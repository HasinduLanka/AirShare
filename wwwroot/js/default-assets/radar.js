(function(){var a=window.AmCharts;a.AmSlicedChart=a.Class({inherits:a.AmChart,construct:function(b){this.createEvents("rollOverSlice","rollOutSlice","clickSlice","pullOutSlice","pullInSlice","rightClickSlice");a.AmSlicedChart.base.construct.call(this,b);this.colors="#FF0F00 #FF6600 #FF9E01 #FCD202 #F8FF01 #B0DE09 #04D215 #0D8ECF #0D52D1 #2A0CD0 #8A0CCF #CD0D74 #754DEB #DDDDDD #999999 #333333 #000000 #57032A #CA9726 #990000 #4B0C25".split(" ");this.alpha=1;this.groupPercent=0;this.groupedTitle="Other";this.groupedPulled=!1;this.groupedAlpha=1;this.marginLeft=0;this.marginBottom=this.marginTop=10;this.marginRight=0;this.hoverAlpha=1;this.outlineColor="#FFFFFF";this.outlineAlpha=0;this.outlineThickness=1;this.startAlpha=0;this.startDuration=1;this.startEffect="bounce";this.sequencedAnimation=!0;this.pullOutDuration=1;this.pullOutEffect="bounce";this.pullOnHover=this.pullOutOnlyOne=!1;this.labelsEnabled=!0;this.labelTickColor="#000000";this.labelTickAlpha=0.2;this.hideLabelsPercent=0;this.urlTarget="_self";this.autoMarginOffset=10;this.gradientRatio=[];this.maxLabelWidth=200;this.accessibleLabel="[[title]]: [[percents]]% [[value]] [[description]]";a.applyTheme(this,b,"AmSlicedChart")},initChart:function(){a.AmSlicedChart.base.initChart.call(this);this.dataChanged&&(this.parseData(),this.dispatchDataUpdated=!0,this.dataChanged=!1,this.setLegendData(this.chartData));this.drawChart()},handleLegendEvent:function(f){var e=f.type,j=f.dataItem,i=this.legend;if(j.wedge&&j){var h=j.hidden;f=f.event;switch(e){case"clickMarker":h||i.switchable||this.clickSlice(j,f);break;case"clickLabel":h||this.clickSlice(j,f,!1);break;case"rollOverItem":h||this.rollOverSlice(j,!1,f);break;case"rollOutItem":h||this.rollOutSlice(j,f);break;case"hideItem":this.hideSlice(j,f);break;case"showItem":this.showSlice(j,f)}}},invalidateVisibility:function(){this.recalculatePercents();this.initChart();var b=this.legend;b&&b.invalidateSize()},addEventListeners:function(e,d){var f=this;e.mouseover(function(b){f.rollOverSlice(d,!0,b)}).mouseout(function(b){f.rollOutSlice(d,b)}).touchend(function(b){f.rollOverSlice(d,b)}).mouseup(function(b){f.clickSlice(d,b)}).contextmenu(function(b){f.handleRightClick(d,b)})},formatString:function(f,e,h){f=a.formatValue(f,e,["value"],this.nf,"",this.usePrefixes,this.prefixesOfSmallNumbers,this.prefixesOfBigNumbers);var g=this.pf.precision;isNaN(this.tempPrec)||(this.pf.precision=this.tempPrec);f=a.formatValue(f,e,["percents"],this.pf);f=a.massReplace(f,{"[[title]]":e.title,"[[description]]":e.description});this.pf.precision=g;-1!=f.indexOf("[[")&&(f=a.formatDataContextValue(f,e.dataContext));f=h?a.fixNewLines(f):a.fixBrakes(f);return f=a.cleanFromEmpty(f)},startSlices:function(){var b;for(b=0;b<this.chartData.length;b++){0<this.startDuration&&this.sequencedAnimation?this.setStartTO(b):this.startSlice(this.chartData[b])}},setStartTO:function(d){var c=this;d=setTimeout(function(){c.startSequenced.call(c)},c.startDuration/c.chartData.length*500*d);c.timeOuts.push(d)},pullSlices:function(f){var e=this.chartData,h;for(h=0;h<e.length;h++){var g=e[h];g.pulled&&this.pullSlice(g,1,f)}},startSequenced:function(){var d=this.chartData,c;for(c=0;c<d.length;c++){if(!d[c].started){this.startSlice(this.chartData[c]);break}}},startSlice:function(f){f.started=!0;var e=f.wedge,h=this.startDuration,g=f.labelSet;e&&0<h&&(0<f.alpha&&e.show(),e.translate(f.startX,f.startY),this.animatable.push(e),e.animate({opacity:1,translate:"0,0"},h,this.startEffect));g&&0<h&&(0<f.alpha&&g.show(),g.translate(f.startX,f.startY),g.animate({opacity:1,translate:"0,0"},h,this.startEffect))},showLabels:function(){var f=this.chartData,e;for(e=0;e<f.length;e++){var h=f[e];if(0<h.alpha){var g=h.label;g&&g.show();(h=h.tick)&&h.show()}}},showSlice:function(b){isNaN(b)?b.hidden=!1:this.chartData[b].hidden=!1;this.invalidateVisibility()},hideSlice:function(b){isNaN(b)?b.hidden=!0:this.chartData[b].hidden=!0;this.hideBalloon();this.invalidateVisibility()},rollOverSlice:function(i,e,n){isNaN(i)||(i=this.chartData[i]);clearTimeout(this.hoverInt);if(!i.hidden){this.pullOnHover&&this.pullSlice(i,1);1>this.hoverAlpha&&i.wedge&&i.wedge.attr({opacity:this.hoverAlpha});var m=i.balloonX,k=i.balloonY;i.pulled&&(m+=i.pullX,k+=i.pullY);var l=this.formatString(this.balloonText,i,!0),j=this.balloonFunction;j&&(l=j(i,l));j=a.adjustLuminosity(i.color,-0.15);l?this.showBalloon(l,j,e,m,k):this.hideBalloon();0===i.value&&this.hideBalloon();this.fire({type:"rollOverSlice",dataItem:i,chart:this,event:n})}},rollOutSlice:function(d,c){isNaN(d)||(d=this.chartData[d]);d.wedge&&d.wedge.attr({opacity:1});this.hideBalloon();this.fire({type:"rollOutSlice",dataItem:d,chart:this,event:c})},clickSlice:function(e,d,f){this.checkTouchDuration(d)&&(isNaN(e)||(e=this.chartData[e]),e.pulled?this.pullSlice(e,0):this.pullSlice(e,1),a.getURL(e.url,this.urlTarget),f||this.fire({type:"clickSlice",dataItem:e,chart:this,event:d}))},handleRightClick:function(d,c){isNaN(d)||(d=this.chartData[d]);this.fire({type:"rightClickSlice",dataItem:d,chart:this,event:c})},drawTicks:function(){var f=this.chartData,e;for(e=0;e<f.length;e++){var h=f[e];if(h.label&&!h.skipTick){var g=h.ty,g=a.line(this.container,[h.tx0,h.tx,h.tx2],[h.ty0,g,g],this.labelTickColor,this.labelTickAlpha);a.setCN(this,g,this.type+"-tick");a.setCN(this,g,h.className,!0);h.tick=g;h.wedge.push(g);"AmFunnelChart"==this.cname&&g.toBack()}}},initialStart:function(){var e=this,d=e.startDuration,f=setTimeout(function(){e.showLabels.call(e)},1000*d);e.timeOuts.push(f);e.chartCreated?e.pullSlices(!0):(e.startSlices(),0<d?(d=setTimeout(function(){e.pullSlices.call(e)},1200*d),e.timeOuts.push(d)):e.pullSlices(!0))},pullSlice:function(f,e,h){var g=this.pullOutDuration;!0===h&&(g=0);if(h=f.wedge){0<g?(h.animate({translate:e*f.pullX+","+e*f.pullY},g,this.pullOutEffect),f.labelSet&&f.labelSet.animate({translate:e*f.pullX+","+e*f.pullY},g,this.pullOutEffect)):(f.labelSet&&f.labelSet.translate(e*f.pullX,e*f.pullY),h.translate(e*f.pullX,e*f.pullY))}1==e?(f.pulled=!0,this.pullOutOnlyOne&&this.pullInAll(f.index),f={type:"pullOutSlice",dataItem:f,chart:this}):(f.pulled=!1,f={type:"pullInSlice",dataItem:f,chart:this});this.fire(f)},pullInAll:function(e){var d=this.chartData,f;for(f=0;f<this.chartData.length;f++){f!=e&&d[f].pulled&&this.pullSlice(d[f],0)}},pullOutAll:function(){var d=this.chartData,c;for(c=0;c<d.length;c++){d[c].pulled||this.pullSlice(d[c],1)}},parseData:function(){var j=[];this.chartData=j;var i=this.dataProvider;isNaN(this.pieAlpha)||(this.alpha=this.pieAlpha);if(void 0!==i){var p=i.length,o=0,l,m,k;for(l=0;l<p;l++){m={};var n=i[l];m.dataContext=n;null!==n[this.valueField]&&(m.value=Number(n[this.valueField]));(k=n[this.titleField])||(k="");m.title=k;m.pulled=a.toBoolean(n[this.pulledField],!1);(k=n[this.descriptionField])||(k="");m.description=k;m.labelRadius=Number(n[this.labelRadiusField]);m.switchable=!0;m.className=n[this.classNameField];m.url=n[this.urlField];k=n[this.patternField];!k&&this.patterns&&(k=this.patterns[l]);m.pattern=k;m.visibleInLegend=a.toBoolean(n[this.visibleInLegendField],!0);k=n[this.alphaField];m.alpha=void 0!==k?Number(k):this.alpha;k=n[this.colorField];void 0!==k&&(m.color=k);m.labelColor=a.toColor(n[this.labelColorField]);o+=m.value;m.hidden=!1;j[l]=m}for(l=i=0;l<p;l++){m=j[l],m.percents=m.value/o*100,m.percents<this.groupPercent&&i++}1<i&&(this.groupValue=0,this.removeSmallSlices(),j.push({title:this.groupedTitle,value:this.groupValue,percents:this.groupValue/o*100,pulled:this.groupedPulled,color:this.groupedColor,url:this.groupedUrl,description:this.groupedDescription,alpha:this.groupedAlpha,pattern:this.groupedPattern,className:this.groupedClassName,dataContext:{}}));p=this.baseColor;p||(p=this.pieBaseColor);o=this.brightnessStep;o||(o=this.pieBrightnessStep);for(l=0;l<j.length;l++){p?k=a.adjustLuminosity(p,l*o/100):(k=this.colors[l],void 0===k&&(k=a.randomColor())),void 0===j[l].color&&(j[l].color=k)}this.recalculatePercents()}},recalculatePercents:function(){var f=this.chartData,e=0,h,g;for(h=0;h<f.length;h++){g=f[h],!g.hidden&&0<g.value&&(e+=g.value)}for(h=0;h<f.length;h++){g=this.chartData[h],g.percents=!g.hidden&&0<g.value?100*g.value/e:0}},removeSmallSlices:function(){var d=this.chartData,c;for(c=d.length-1;0<=c;c--){d[c].percents<this.groupPercent&&(this.groupValue+=d[c].value,d.splice(c,1))}},animateAgain:function(){var f=this;f.startSlices();for(var e=0;e<f.chartData.length;e++){var h=f.chartData[e];h.started=!1;var g=h.wedge;g&&(g.setAttr("opacity",f.startAlpha),g.translate(h.startX,h.startY));if(g=h.labelSet){g.setAttr("opacity",f.startAlpha),g.translate(h.startX,h.startY)}}e=f.startDuration;0<e?(e=setTimeout(function(){f.pullSlices.call(f)},1200*e),f.timeOuts.push(e)):f.pullSlices()},measureMaxLabel:function(){var h=this.chartData,e=0,l;for(l=0;l<h.length;l++){var k=h[l],i=this.formatString(this.labelText,k),j=this.labelFunction;j&&(i=j(k,i));k=a.text(this.container,i,this.color,this.fontFamily,this.fontSize);i=k.getBBox().width;i>e&&(e=i);k.remove()}return e}})})();(function(){var a=window.AmCharts;a.AmPieChart=a.Class({inherits:a.AmSlicedChart,construct:function(b){this.type="pie";a.AmPieChart.base.construct.call(this,b);this.cname="AmPieChart";this.pieBrightnessStep=30;this.minRadius=10;this.depth3D=0;this.startAngle=90;this.angle=this.innerRadius=0;this.startRadius="500%";this.pullOutRadius="20%";this.labelRadius=20;this.labelText="[[title]]: [[percents]]%";this.balloonText="[[title]]: [[percents]]% ([[value]])\n[[description]]";this.previousScale=1;this.adjustPrecision=!1;this.gradientType="radial";a.applyTheme(this,b,this.cname)},drawChart:function(){a.AmPieChart.base.drawChart.call(this);var Z=this.chartData;if(a.ifArray(Z)){if(0<this.realWidth&&0<this.realHeight){a.VML&&(this.startAlpha=1);var Y=this.startDuration,X=this.container,W=this.updateWidth();this.realWidth=W;var T=this.updateHeight();this.realHeight=T;var U=a.toCoordinate,S=U(this.marginLeft,W),V=U(this.marginRight,W),i=U(this.marginTop,T)+this.getTitleHeight(),P=U(this.marginBottom,T)+this.depth3D,O,L,Q,o=a.toNumber(this.labelRadius),M=this.measureMaxLabel();M>this.maxLabelWidth&&(M=this.maxLabelWidth);this.labelText&&this.labelsEnabled||(o=M=0);O=void 0===this.pieX?(W-S-V)/2+S:U(this.pieX,this.realWidth);L=void 0===this.pieY?(T-i-P)/2+i:U(this.pieY,T);Q=U(this.radius,W,T);Q||(W=0<=o?W-S-V-2*M:W-S-V,T=T-i-P,Q=Math.min(W,T),T<W&&(Q/=1-this.angle/90,Q>W&&(Q=W)),T=a.toCoordinate(this.pullOutRadius,Q),Q=(0<=o?Q-1.8*(o+T):Q-1.8*T)/2);Q<this.minRadius&&(Q=this.minRadius);T=U(this.pullOutRadius,Q);i=a.toCoordinate(this.startRadius,Q);U=U(this.innerRadius,Q);U>=Q&&(U=Q-1);P=a.fitToBounds(this.startAngle,0,360);0<this.depth3D&&(P=270<=P?270:90);P-=90;360<P&&(P-=360);W=Q-Q*this.angle/90;for(S=M=0;S<Z.length;S++){V=Z[S],!0!==V.hidden&&(M+=a.roundTo(V.percents,this.pf.precision))}M=a.roundTo(M,this.pf.precision);this.tempPrec=NaN;this.adjustPrecision&&100!=M&&(this.tempPrec=this.pf.precision+1);for(var H,S=0;S<Z.length;S++){if(V=Z[S],!0!==V.hidden&&(this.showZeroSlices||0!==V.percents)){var K=360*V.percents/100,M=Math.sin((P+K/2)/180*Math.PI),J=W/Q*-Math.cos((P+K/2)/180*Math.PI),N=this.outlineColor;N||(N=V.color);var F=this.alpha;isNaN(V.alpha)||(F=V.alpha);N={fill:V.color,stroke:N,"stroke-width":this.outlineThickness,"stroke-opacity":this.outlineAlpha,"fill-opacity":F};V.url&&(N.cursor="pointer");N=a.wedge(X,O,L,P,K,Q,W,U,this.depth3D,N,this.gradientRatio,V.pattern,this.path,this.gradientType);a.setCN(this,N,"pie-item");a.setCN(this,N.wedge,"pie-slice");a.setCN(this,N,V.className,!0);this.addEventListeners(N,V);V.startAngle=P;Z[S].wedge=N;0<Y&&(this.chartCreated||N.setAttr("opacity",this.startAlpha));V.ix=M;V.iy=J;V.wedge=N;V.index=S;V.label=null;F=X.set();if(this.labelsEnabled&&this.labelText&&V.percents>=this.hideLabelsPercent){var R=P+K/2;0>R&&(R+=360);360<R&&(R-=360);var G=o;isNaN(V.labelRadius)||(G=V.labelRadius,0>G&&(V.skipTick=!0));var K=O+M*(Q+G),I=L+J*(Q+G),k,s=0;isNaN(H)&&350<R&&1<Z.length-S&&(H=S-1+Math.floor((Z.length-S)/2));if(0<=G){var j;90>=R&&0<=R?(j=0,k="start",s=8):90<=R&&180>R?(j=1,k="start",s=8):180<=R&&270>R?(j=2,k="end",s=-8):270<=R&&354>=R?(j=3,k="end",s=-8):354<=R&&(S>H?(j=0,k="start",s=8):(j=3,k="end",s=-8));V.labelQuarter=j}else{k="middle"}R=this.formatString(this.labelText,V);(G=this.labelFunction)&&(R=G(V,R));G=V.labelColor;G||(G=this.color);""!==R&&(R=a.wrappedText(X,R,G,this.fontFamily,this.fontSize,k,!1,this.maxLabelWidth),a.setCN(this,R,"pie-label"),a.setCN(this,R,V.className,!0),R.translate(K+1.5*s,I),0>o&&(R.node.style.pointerEvents="none"),R.node.style.cursor="default",V.ty=I,V.textX=K+1.5*s,F.push(R),this.axesSet.push(F),V.labelSet=F,V.label=R,this.addEventListeners(F,V));V.tx=K;V.tx2=K+s;V.tx0=O+M*Q;V.ty0=L+J*Q}K=U+(Q-U)/2;V.pulled&&(K+=T);this.accessible&&this.accessibleLabel&&(I=this.formatString(this.accessibleLabel,V),this.makeAccessible(N,I));void 0!==this.tabIndex&&N.setAttr("tabindex",this.tabIndex);V.balloonX=M*K+O;V.balloonY=J*K+L;V.startX=Math.round(M*i);V.startY=Math.round(J*i);V.pullX=Math.round(M*T);V.pullY=Math.round(J*T);this.graphsSet.push(N);if(0===V.alpha||0<Y&&!this.chartCreated){N.hide(),F&&F.hide()}P+=360*V.percents/100;360<P&&(P-=360)}}0<o&&this.arrangeLabels();this.pieXReal=O;this.pieYReal=L;this.radiusReal=Q;this.innerRadiusReal=U;0<o&&this.drawTicks();this.initialStart();this.setDepths()}(Z=this.legend)&&Z.invalidateSize()}else{this.cleanChart()}this.dispDUpd()},setDepths:function(){var f=this.chartData,e;for(e=0;e<f.length;e++){var h=f[e],g=h.wedge,h=h.startAngle;0<=h&&180>h?g.toFront():180<=h&&g.toBack()}},arrangeLabels:function(){var f=this.chartData,e=f.length,h,g;for(g=e-1;0<=g;g--){h=f[g],0!==h.labelQuarter||h.hidden||this.checkOverlapping(g,h,0,!0,0)}for(g=0;g<e;g++){h=f[g],1!=h.labelQuarter||h.hidden||this.checkOverlapping(g,h,1,!1,0)}for(g=e-1;0<=g;g--){h=f[g],2!=h.labelQuarter||h.hidden||this.checkOverlapping(g,h,2,!0,0)}for(g=0;g<e;g++){h=f[g],3!=h.labelQuarter||h.hidden||this.checkOverlapping(g,h,3,!1,0)}},checkOverlapping:function(t,s,r,q,m){var o,l,p=this.chartData,j=p.length,i=s.label;if(i){if(!0===q){for(l=t+1;l<j;l++){p[l].labelQuarter==r&&(o=this.checkOverlappingReal(s,p[l],r))&&(l=j)}}else{for(l=t-1;0<=l;l--){p[l].labelQuarter==r&&(o=this.checkOverlappingReal(s,p[l],r))&&(l=0)}}!0===o&&200>m&&isNaN(s.labelRadius)&&(o=s.ty+3*s.iy,s.ty=o,i.translate(s.textX,o),this.checkOverlapping(t,s,r,q,m+1))}},checkOverlappingReal:function(h,e,l){var k=!1,i=h.label,j=e.label;h.labelQuarter!=l||h.hidden||e.hidden||!j||(i=i.getBBox(),l={},l.width=i.width,l.height=i.height,l.y=h.ty,l.x=h.tx,h=j.getBBox(),j={},j.width=h.width,j.height=h.height,j.y=e.ty,j.x=e.tx,a.hitTest(l,j)&&(k=!0));return k}})})();