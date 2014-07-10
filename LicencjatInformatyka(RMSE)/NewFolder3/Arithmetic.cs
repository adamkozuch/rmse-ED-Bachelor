using System;
using System.Collections.Generic;

namespace LicencjatInformatyka_RMSE_.NewFolder3
{
    class Arithmetic
    {

        // zrobić ją statyczna
        private int Znak(string znak, string variable1,string variable2)
        {

            int var1 = int.Parse(variable1);
            int var2 = int.Parse(variable2);



            if (znak == "+")
            {
                return var1 + var2;
            } else if (znak=="-")
            {
                return var1 - var2;
            } else if (znak=="*")
            {
                return var1*var2;
            }else if (znak == "/")
            {
                return var1/var2;
            }else if (znak=="=")
            {
                return var1 = var2;
            } else if (znak=="div")
            {
                
            }else if (znak == "mod")
            {
               
                return var1%var2;
            }else if (znak=="min")
            {
                return Math.Min(var1, var2);
            }else if (znak == "max")
            {
                return Math.Max(var1, var2);
            }else if (znak=="%")
            {
                
            }else if (znak=="zaokraglenie_do_N")
            {
                
            }else if (znak == "A^N")
            {
                
            }

            return 1;

        }


        //private double Znak1(string znak,string variable)
        //{

        //   double var1 = double.Parse(variable);
          

        //    if (znak == "sqrt")
        //    {
        //     return   Math.Sqrt(var1);
        //    }
        //    else if (znak == "sin")
        //    {
        //      return  Math.Sin(var1);
        //    }
        //    else if (znak == "cos")
        //    {
        //       return Math.Cos(var1);
        //    }
        //    else if (znak == "tan")
        //    {
        //      return  Math.Tan(var1);
        //    }
        //    else if (znak == "arctan")
        //    {
        //       return Math.Atan(var1);
        //    }
        //    else if (znak == "log")
        //    {
        //        //Math.Log(var1,)
        //    }
        //    else if (znak == "ln")
        //    {
        //        //Math.l
        //    }
        //    else if (znak == "exp")
        //    {

        //    }
        //    else if (znak == "round")
        //    {
        //        Math.Round(var1);
        //    }
        //    else if (znak == "trunc")
        //    {
        //        Math.Truncate(var1);
        //    }
        //    else if (znak == "abs")
        //    {
        //        Math.Abs(var1);
        //    }    
        //}

        public int LinearValue(List<string>farctorsList, List<string>variablesList  )
        {

            int result = 0;
            for (int i = 0; i < farctorsList.Count; i++)
            {
                int factor = int.Parse(farctorsList[i]);
                int variable = int.Parse(variablesList[i]);
                result += factor*variable;
            }

            return result;
        }

        public void ExtendedArithmeticModel(List<string> r,  string znak)
        {
            if (znak == "+")
            {
                
            }else if (znak == "*")
            {
                
            }else if (znak == "min_list")
            {
                
            }else if (znak == "max_list")
            {
                
            }
                
        }

        //public int ExtendedRelationalModel(string znak)
        //{
        //    if (znak == "<,<")
        //    {

        //    }
        //    else if (znak == "<,<=")
        //    {

        //    }
        //    else if (znak == "<=,<")
        //    {

        //    }
        //    else if (znak == "<=,<=")
        //    {

        //    }

        //}

    }
}
