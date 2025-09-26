// using FluentCalculator.Values;
namespace Fluent;

public class FluentCalculator
{
    public Values Zero => new Values(null,0);
    public Values One => new Values(null,1);
    public Values Two => new Values(null,2);
    public Values Three => new Values(null,3);
    public Values Four => new Values(null,4);
    public Values Five => new Values(null,5);
    public Values Six => new Values(null,6);
    public Values Seven => new Values(null,7);
    public Values Eight => new Values(null,8);
    public Values Nine => new Values(null,9);
    public Values Ten => new Values(null,10);


    public static double ExecFluent(){
        var calculator = new FluentCalculator();
        double result = 0;
        result = calculator.One.Plus.Three.Times.Two.Minus.Nine.DividedBy.Three;
        Console.WriteLine("result " + result);

        // 1+3*2-9/3  = 4
        result = calculator.One.Plus.Three.Times.Two.Minus.Nine.DividedBy.Three;
        Console.WriteLine("result " + result);

        // 1+3*2-9/2=2.5
        result = calculator.One.Plus.Three.Times.Two.Minus.Nine.DividedBy.Two;
        Console.WriteLine("result " + result);

        //9+2+3+2*6/3 = 18
        result = calculator.Nine.Plus.Two.Plus.Three.Plus.Two.Times.Six.DividedBy.Three;
        Console.WriteLine("result " + result);

        //4*5/2-3+9+2+3+2*6/3*4*/6*3 = 10-3+9+2+3+8 = 29
        result = calculator.Four.Times.Five.DividedBy.Two.Minus.Three.Plus.Nine.Plus.Two.Plus.Three.Plus.Two.Times.Six.DividedBy.Three.Times.Four.DividedBy.Six.Times.Three;
        Console.WriteLine("result " + result);
        return result;
    }
}

