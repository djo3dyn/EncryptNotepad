using System;  
using System.IO;  
using System.Security.Cryptography;  
using System.Text;  
  
namespace EncryptDecryptSymetric 
{  
    public class AesOperation  
    { 
        // Edited
        public static string EncryptString(byte[] key, string plainText)  
            {  
                byte[] iv = new byte[16];  
                byte[] array;  
    
                using (Aes aes = Aes.Create())  
                {  
                    aes.Key = key;  
                    aes.IV = iv;  
    
                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);  
    
                    using (MemoryStream memoryStream = new MemoryStream())  
                    {  
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))  
                        {  
                            using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))  
                            {  
                                streamWriter.Write(plainText);  
                            }  
    
                            array = memoryStream.ToArray();  
                        }  
                    }  
                }  
  
            return Convert.ToBase64String(array);  
        }  
  
        public static string DecryptString(byte[] key, string cipherText)  
        {  
            byte[] iv = new byte[16];
            byte[] buffer = null;
            try
            {
                buffer = Convert.FromBase64String(cipherText);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
  
            using (Aes aes = Aes.Create())  
            {  
                aes.Key = key;  
                aes.IV = iv;  
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);  
  
                using (MemoryStream memoryStream = new MemoryStream(buffer))  
                {
                    try
                    {
                        using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                            {
                                return streamReader.ReadToEnd();
                            }
                        }
                    }
                    catch (CryptographicException e)
                    {
                        Console.WriteLine(e.ToString());
                        return null;
                    }
                }  
            }  
        }

        // TODO : check encrypted text
        /*
         * Ciri-ciri :
            lebih dari 24 char
            diakhiri ==
            tidak ada spasi
        */
        public static bool CheckEncrypted(string rawtext)
        {
            if (rawtext.Length >= 24)
            {
                if (!rawtext.Contains(" ") || rawtext.EndsWith("=="))
                {
                    return true;
                }
                else return false;  
            }
            else return false;
        }
    }  
}  