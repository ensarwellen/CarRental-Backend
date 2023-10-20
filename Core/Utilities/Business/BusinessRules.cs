using Core.Results.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //params: birden fazla parametre göndermeye yarar
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;   //kurala UYMAYANI döndürür
                }
            }
            return null;
        }
    }
}
