using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MediConnect.Utils
{
    public class ProductNumberGenerator
    {
        private static int productCounter = 1;

        public static string Generate(int ownerId)
        {
            string ownerIdString = ownerId.ToString("0000");
            string productNumberString = productCounter.ToString("0000");

            string productNumber = $"MC{ownerIdString}{productNumberString}";
            productCounter++;
            return productNumber;
        }
    }
}