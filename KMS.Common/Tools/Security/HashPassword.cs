using System.Linq;
using System;
using System.Security.Cryptography;
using System.Text;

namespace KMS.Common.Tools.Security;

public static class HashPassword
{

    public static string MD5Hash(string pass)
    {
        MD5 md5H = MD5.Create();
        byte[] data = md5H.ComputeHash(Encoding.UTF8.GetBytes(pass));
        StringBuilder sB = new StringBuilder();
        for (int i = 0; i < data.Length; i++)
        {
            sB.Append(data[i].ToString("x2"));
        }
        return sB.ToString();
    }
}