using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace Account_Gen
{
    class HWID
    {
        public static string Method_0(string IP)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(IP);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string Method_1(string CPU)
        {
            MD5 Tru = new MD5CryptoServiceProvider();
            Tru.ComputeHash(ASCIIEncoding.ASCII.GetBytes(CPU));
            byte[] result = Tru.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }

        public static string Generate_1()
        {
            ManagementObjectCollection objects = null;
            objects = new ManagementObjectSearcher("Select * From Win32_processor").Get();
            string str = "";
            foreach (ManagementObject obj2 in objects)
            {
                str = obj2["ProcessorID"].ToString();
            }
            ManagementObject obj3 = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            obj3.Get();
            string str2 = obj3["VolumeSerialNumber"].ToString();
            return (str + str2);
        }

        public static string CreateSalt()
        {
            Random rnd = new Random();
            string schar = "0123456789abcdefghijklmnopqrstuvwxyz";
            string finalSalt = "";
            for (int i = 0; i < 15; i++)
            {
                finalSalt += schar.ToCharArray(rnd.Next(0, schar.Length - 1), 1);
            }
            return finalSalt;
        }

        public static string Generate_2()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");

            foreach (ManagementObject wmi_HD in searcher.Get())
            {
                if (wmi_HD["SerialNumber"] != null)
                    return wmi_HD["SerialNumber"].ToString();
            }
            return string.Empty;
        }
    }
}
    

