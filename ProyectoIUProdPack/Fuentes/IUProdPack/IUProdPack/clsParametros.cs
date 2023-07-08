using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUProdPack
{
    public class clsParametros
    {
        public clsParametros()
        {
        }

        public static string manejoError(string p_error)
        {
            string pError;
            try
            {
                int num = 0;
                int num1 = 0;
                int num2 = 0;
                while (num2 < p_error.Length)
                {
                    if (p_error.Substring(num2, 9).Equals("ORA-20001"))
                    {
                        num = num2 + 11;
                    }
                    if (!p_error.Substring(num2, 9).Equals("ORA-06512"))
                    {
                        num2++;
                    }
                    else
                    {
                        num1 = num2 - 1;
                        pError = p_error.Substring(num, num1 - num);
                        return pError;
                    }
                }
                pError = p_error;
            }
            catch (Exception exception)
            {
                string message = exception.Message;
                pError = p_error;
            }
            return pError;
        }
    }
}