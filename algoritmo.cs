using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;


namespace EnCryptDecrypt
{
    class cript
    {
        public static string Encriptar(string palavra, bool md, string chave)
        {
            byte[] arrayChave;
            byte[] novoArray = UTF8Encoding.UTF8.GetBytes(palavra);


            if (md)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                arrayChave = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(chave));
                hashmd5.Clear();
            }
            else
                arrayChave = UTF8Encoding.UTF8.GetBytes(chave);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = arrayChave;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultado = cTransform.TransformFinalBlock(novoArray, 0, novoArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultado, 0, resultado.Length);
        }



        public static string Descriptar(string palavra, bool md, string chave)
        {
            byte[] arrayChave;
            byte[] novoArray = Convert.FromBase64String(palavra);


            if (md)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                arrayChave = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(chave));
                hashmd5.Clear();
            }
            else
                arrayChave = UTF8Encoding.UTF8.GetBytes(chave);

            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = arrayChave;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = des.CreateDecryptor();
            byte[] resultado = cTransform.TransformFinalBlock(novoArray, 0, novoArray.Length);

            des.Clear();
            return UTF8Encoding.UTF8.GetString(resultado);
        }
    }
}
