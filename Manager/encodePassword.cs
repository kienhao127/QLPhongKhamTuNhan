using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    class encodePassword
    {
        static public string Encode(string pw)
        {
            if (pw.Length == 0) return null;
            ulong lEnPw = 1;
            int length = pw.Length;
            for (int i = 0; i < length; i++)
            {
                lEnPw = lEnPw * (ulong)Math.Pow(10, ((int)pw[i]).ToString().Length - 1) + (ulong)pw[i];
                if (lEnPw > Math.Pow(10, 16))
                    lEnPw = (lEnPw % (ulong)Math.Pow(10, 16)) + (lEnPw / (ulong)Math.Pow(10, 16));
            }
            while (lEnPw.ToString().Length < 16)
            {
                lEnPw = (lEnPw % 10 == 0) ? lEnPw / 10 : lEnPw;
                lEnPw *= (lEnPw % 100) != 1 ? (lEnPw % 100) : 2;
                lEnPw = (lEnPw % 10 == 0) ? lEnPw / 10 : lEnPw;
            }
            return lEnPw.ToString().Length > 16 ? ((ulong)(lEnPw / (Math.Pow(10, lEnPw.ToString().Length - 1)) + lEnPw % (Math.Pow(10, 16)))).ToString() : lEnPw.ToString();
        }
    }
}
