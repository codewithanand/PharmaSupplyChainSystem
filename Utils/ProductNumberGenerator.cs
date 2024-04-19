using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediConnect.Utils
{
    public class ProductNumberGenerator
    {
        private static int productCounter = 1;

        public static string Generate(int manufacturerId)
        {
            string manufaturerIdString = manufacturerId.ToString("0000");
            string productNumberString = productCounter.ToString("0000");

            string productNumber = $"MC{manufaturerIdString}{productNumberString}";
            productCounter++;
            return productNumber;
        }
    }
}