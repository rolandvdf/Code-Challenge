using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomCalculator
{
    public class Calculator : ICalculator
    {
        public double EvaluateOperations(string oper)
        {
            if (oper.Contains('+') || !CointainsOperator(oper))
            {
                return GetSum(oper);
            }
            else if (oper.Contains('-'))
            {
                return GetMin(oper);
            }
            else if (oper.Contains('*'))
            {
                return GetMultiply(oper);
            }
            else if (oper.Contains('/'))
            {
                return GetDevide(oper);
            }
            return 0;
            //throw new InvalidOperationException("The string contains a invalid operation!");
        }

        private double GetDevide(string oper)
        {
            var results = oper.Split('/');
            double devide = 0;
            if (results.Length > 0)
            {
                devide = EvaluateOperations(results[0]);
                for (int i = 1; i < results.Length; i++)
                {
                    if (!string.IsNullOrEmpty(results[i]))
                    {

                        devide = devide / EvaluateOperations(oper);

                    }
                }
            }
            return devide;
        }

        private double GetMultiply(string oper)
        {
            var results = oper.Split('*');
            double Multiply = 0;
            if (results.Length > 0)
            {
                Multiply = EvaluateOperations(results[0]);
                for (int i = 1; i < results.Length; i++)
                {
                    if (!string.IsNullOrEmpty(results[i]))
                    {

                        Multiply = Multiply * EvaluateOperations(oper);

                    }
                }
            }
            return Multiply;
        }

        private double GetSum(string oper)
        {
            var results = oper.Split('+');
            double sum = 0;
            foreach (var result in results)
            {
                if (!string.IsNullOrEmpty(result))
                {
                    if (CointainsOperator(result))
                    {
                        sum += EvaluateOperations(oper);
                    }
                    else
                    {
                        try
                        {
                            sum += Double.Parse(result);
                        }
                        catch (Exception)
                        {

                            throw new InvalidOperationException("The string contains a invalid operation!");
                        }
                    }
                }
            }
            return sum;

        }

        private double GetMin(string oper)
        {
            var results = oper.Split('-');
            double min = 0;
            if (results.Length > 0)
            {
                min = ConvertResult(results[0]);
                for (int i = 1; i < results.Length; i++)
                {
                    if (!string.IsNullOrEmpty(results[i]))
                    {
                        if (CointainsOperator(results[i]))
                        {
                            min -= EvaluateOperations(oper);
                        }
                        else
                        {
                            min -= ConvertResult(results[i]);
                        }
                    }
                }
            }
            return min;

        }

        private static double ConvertResult(string results)
        {
            try
            {
                return Double.Parse(results);
            }
            catch (Exception)
            {

                throw new InvalidOperationException("The string contains a invalid operation!");
            }

        }

        private bool CointainsOperator(string result)
        {
            return result.Contains("+") || result.Contains("-");
        }
    }
}
