using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Text.RegularExpressions;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Library
{
    public class StringUtility
    {
        private static string[,] sArray = new string[14, 18];

        public static string ChangeFormatDateTime(int InputFormatType, int OutputFormatType, string Datetime)
        {
            //1: dd/MM/yyyy hh:mm:ss t
            //2: MM/dd/yyyy hh:mm:ss t

            //3: yyyy/MM/dd hh:mm:ss t
            //4: yyyy/dd/MM hh:mm:ss t
            



            string[] Key = { "/","/"," ",":",":"," " };
            string[] data = new string[7];
            data = Datetime.Split(Key, StringSplitOptions.None);
            string ret;
            try
            {
                 ret = data[1] + "/" + data[0] + "/" + data[2] + " " + data[3] + ":" + data[4];
            }
            catch
            {
                 ret = data[1] + "/" + data[0] + "/" + data[2];
            }
            return ret;
        }

        public static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }

        public static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }

        public static string CreateUsername(string name)
        {
            name = ConvertToUnSign(name);
            string[] names = name.Split(' ');
            int n = names.Length;
            string fistname = names[n - 1];
            string lastname = "";
            for (int i = 0; i < n - 1; i++)
            {
                lastname += names[i].Substring(0, 1).ToUpper();
            }
            string username = fistname + lastname;
            return username;
        }

        public static string ConvertToUnSign(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
       
        //Hiennv   03/11/2014
        public static string ConvertDecimalToString(decimal number)
        {
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;
            string str = " ";
            bool booAm = false;
            decimal decS = 0;
           

            try
            {
                decS = Convert.ToDecimal(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "một " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "năm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "lẻ " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
            return str + "đồng";
            
        }
        //Hiennv  19/11/2014  ham dung de sinh ma id tu dong
        public static int AutoCreateCode()
        {
            int code = Convert.ToInt32(DateTime.Now.Day.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Millisecond.ToString());
            return -code;
        }
    }
}
