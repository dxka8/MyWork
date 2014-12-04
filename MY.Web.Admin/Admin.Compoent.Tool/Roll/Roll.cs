using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Admin.Compoent.Tool.Roll
{
    public class Roll
    {
        /// <summary>
        /// 伪随机
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public byte[] FalseRollBytes(int count)
        {
            var random = new Random();
            var bytes=new byte[count];
            random.NextBytes(bytes);
            return bytes;
        }
        /// <summary>
        /// 真随机
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public byte[] TureRollBytes(int count)
        {
            var csp = new RNGCryptoServiceProvider();
            var bytes = new byte[count];
            csp.GetBytes(bytes);
            return bytes;
        }

        public string RollStr(int count)
        {
            return "";
        }

        /// <summary>
        /// 去重复随机字符串+数字
        /// </summary>
        /// <param name="codeCount"></param>
        /// <returns></returns>
        public string CreateRandomCode(int codeCount)
        {
            string allChar = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,W,X,Y,Z";
             
            //里面的字符你可以自己加啦
            string[] allCharArray = allChar.Split(',');
            string randomCode = "";
            int temp = -1;
            Random random = new Random();
            for (int i = 0; i < codeCount; i++)
            {
                if (temp != -1)
                {
                    random = new Random(i * temp * (int)DateTime.Now.Ticks);
                }
                int t = random.Next(35);
                if (temp == t)
                {
                    return CreateRandomCode(codeCount);
                }
                temp = t;
                randomCode += allCharArray[temp];
            }
            return randomCode;
        }



    }
}
