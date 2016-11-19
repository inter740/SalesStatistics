using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SalesStatistics.BL.Helpers
{
    public class SecurityHelper
    {
        public static string Hash(string s)
        {
            string hash = string.Empty;

            if (s != null)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(s);

                var csp = new MD5CryptoServiceProvider();

                byte[] byteHash = csp.ComputeHash(bytes);



                foreach (byte b in byteHash)
                    hash += string.Format("{0:x2}", b);
            }


            return hash;
        }
    }
}
