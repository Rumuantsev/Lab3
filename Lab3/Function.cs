using org.mariuszgromada.math.mxparser;

namespace Lab3
{
    public class Function
    {
        string functionString;

        public Function(string functionString)
        {
            this.functionString = functionString;
        }

        public double StandartFunction(double x)
        {
            string func = "f(x) = " + functionString;
            org.mariuszgromada.math.mxparser.Function function = new org.mariuszgromada.math.mxparser.Function(func);
            double Result = function.calculate(x);
            return Result;
        }

        public double MinusFunction(double x)
        {
            string func = "f(x) = (" + functionString + ") * -1.0";
            org.mariuszgromada.math.mxparser.Function function = new org.mariuszgromada.math.mxparser.Function(func);
            double Result = function.calculate(x);
            return Result;
        }

        public double AbsFunction(double x)
        {
            string func = "f(x) = abs(" + functionString + ")";
            org.mariuszgromada.math.mxparser.Function function = new org.mariuszgromada.math.mxparser.Function(func);
            double Result = function.calculate(x);
            return Result;
        }

        public double DerivFunction(double x)
        {
            string xs = x.ToString();
            Expression ex = new Expression("der(" + functionString + ", x, " + xs.Replace(',', '.') + ")");
            return ex.calculate();
        }
    }
}
