using System;
using ScottPlot;
using System.Collections.Generic;
using ScottPlot.Hatches;
using System.Reflection.Metadata;
using ScottPlot.Palettes;

var xs = new List<double>();
var ys = new List<double>();


for(double x=-5; x<=5;x+=0.01){
    xs.Add(x);
    ys.Add(szmierwiastek(x));
}


double szmierwiastek(double x){
    x = Math.Abs(x);
    bool isAlmostInt(double x, double tol=1e-8) => Math.Abs(x-Math.Round(x)) <tol;
    if(isAlmostInt(x) & Math.Round(x)%2==0){
        x = Math.Round(x);
        return x*x/ 4;
    }else if(isAlmostInt(x)){
        x = Math.Round(x);
        return (x*x -1)/4;
    }else
    {
        return (2*x*x -1)/8;
    }
}

var plt = new ScottPlot.Plot();

var d = plt.Add.Scatter(xs,ys);
d.MarkerSize = 0;
plt.Title("Szmierwiastki");
plt.XLabel("x");
plt.YLabel("szm(x)");

var lineY =plt.Add.HorizontalLine(0);
var lineX =plt.Add.VerticalLine(0);

lineY.LinePattern=LinePattern.Dashed;
lineX.LinePattern=LinePattern.Dashed;

plt.SaveSvg("Szmierwiastek.svg",1920,1080);
System.Console.WriteLine("Saved");
