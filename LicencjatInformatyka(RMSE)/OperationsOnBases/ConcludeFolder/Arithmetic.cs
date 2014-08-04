using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LicencjatInformatyka_RMSE_.OperationsOnBases.ConcludeFolder
{
    class Arithmetic
    {

        // zrobić ją statyczna
        public static double? OperationForBasicModel(string znak, string variable1,string variable2)
        {

            float var1 = float.Parse(variable1);
            float var2 = float.Parse(variable2);


            if (var2 != 0)
            {
                #region TwoArguments
                if (znak == "+")
                {
                    return var1 + var2;
                }
                else if (znak == "-")
                {
                    return var1 - var2;
                }
                else if (znak == "*")
                {
                    return var1*var2;
                }
                else if (znak == "/")
                {
                    return var1/var2;
                }
                else if (znak == "=")
                {
                    return var1 = var2;
                }
                else if (znak == "div")
                {

                }
                else if (znak == "mod")
                {

                    return var1%var2;
                }
                else if (znak == "min")
                {
                    return Math.Min(var1, var2);
                }
                else if (znak == "max")
                {
                    return Math.Max(var1, var2);
                }
                else if (znak == "%")
                {

                }
                else if (znak == "zaokraglenie_do_N")
                {

                }
                else if (znak == "A^N")
                {

                }
                #endregion 
            }
            else
            {
                #region OneArgument
                if (znak == "sqrt")
                {
                    return Math.Sqrt(var1);
                }else if (znak=="sin")
                {
                    return Math.Sin(var1);
                }else if (znak=="cos")
                {
                    return Math.Cos(var1);
                }
                else if (znak == "tan")
                {
                    return Math.Tan(var1);
                }
                else if (znak == "arctan")
                {
                    return Math.Atan(var1);
                }
                else if (znak == "log")
                {
                    return Math.Log(var1);
                }
                else if (znak == "ln")
                {
                    return Math.Log10(var1);
                }
                else if (znak == "exp")
                {
                    return Math.Exp(var1);
                }
                else if (znak == "round")
                {
                    return Math.Round(var1);
                }
                else if (znak == "trunc")
                {
                    return Math.Truncate(var1);
                }
                else if (znak == "abs")
                {
                    return Math.Abs(var1);
                }

                #endregion 
            }
            return null;

        }


        public static bool RelationalOperation(string znak, string variable1, string variable2)
        {
          znak=  znak.Replace(" ", "");

            double var1 = double.Parse(variable1);  // Todo: trzeba obsłużyć program w razie przerwania wnioskowania
            double var2 = double.Parse(variable2);

            if (znak == ">")
            {
                return var1>var2;
            }
            else if (znak == "==")
            {
                return var1==var2;
            }
            else if (znak == "<")
            {
                return var1 < var2;
            }
            else if (znak.Equals(">="))
            {
                return var1 >= var2;
            }
            else if (znak.Equals("<="))
            {
                return var1 <= var2;
            }
            //else if (znak == "><")
            //{
            //   // return var1  var2;
            //}
            //else if (znak == "<>")
            //{
            //    //return Math.Atan(var1);
            //}

            MessageBox.Show("Zły znak");
            return false;
        }

        public static string LinearValue(List<string>farctorsList, List<string>variablesList  )
        {

            int result = 0;
            for (int i = 0; i < farctorsList.Count; i++)
            {
                int factor = int.Parse(farctorsList[i]);
                int variable = int.Parse(variablesList[i]);
                result += factor*variable;
            }

            return result.ToString();
        }

        public static string ExtendedArithmeticModel(List<string> argumentList,  string znak)
        {
            znak = znak.Replace(" ", "");
            var numbers = new List<double>();
            foreach (var VARIABLE in argumentList)
            {
                numbers.Add(double.Parse(VARIABLE));
            }
            var result=0.0;

            if (znak == "+")
            {
                foreach (var number in numbers)
                {
                    result += number;
                }
                
            }else if (znak == "*")
            {
                foreach (var number in numbers)
                {
                    if (result == 0)
                    {
                        result = number;
                    }
                    else
                    {
                        result = result*number;
                    }
                }
               
                
            }else if (znak == "min_list")
            {
                result = numbers[0];
                result = numbers.Concat(new[] {result}).Min();
            }
            else if (znak == "max_list")
            {
                result = numbers[0];
                result = numbers.Concat(new[] {result}).Max();
            }
            return result.ToString();
        }

        public static bool ExtendedRelationalModel
            (string znak, string variable1, string variable2,string variable3)
        {

            //double var1 = double.Parse(variable1);
            //double var2 = double.Parse(variable2);
            //double var3 = double.Parse(variable3);

            if (znak == "<,<")
            {
                if(RelationalOperation("<",variable1,variable2))
                    if (RelationalOperation("<", variable2, variable3))
                        return true;
                return false;
            }
            else if (znak == "<,<=")
            {
                if (RelationalOperation("<", variable1, variable2))
                    if (RelationalOperation("<=", variable2, variable3))
                        return true;
                return false;
            }
            else if (znak == "<=,<")
            {
                if (RelationalOperation("<=", variable1, variable2))
                    if (RelationalOperation("<", variable2, variable3))
                        return true;
                return false;
            }
            else if (znak == "<=,<=")
            {
                if (RelationalOperation("<=", variable1, variable2))
                    if (RelationalOperation("<=", variable2, variable3))
                        return true;
                return false;
            }
            return false; //Exception(ex); // jakos to trzeba obsluzyc
        }

        public static string PolynomialModel(string variable, List<string> factorList, List<int> powerList)
        {
            var result=0.0;
            for (int i = 0; i < factorList.Count; i++)
            {
                if (i == 0)
                    result = double.Parse(factorList[i]);
                else
                {
                    result = + double.Parse(factorList[i])*Math.Pow(double.Parse(variable),powerList[i]);

                }


            }
            return result.ToString();
        }

    }
}
