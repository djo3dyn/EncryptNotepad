using System;  
using System.IO;  
using System.Security.Cryptography;  
using System.Text;  
  
namespace EncryptDecryptSymetric 
{  
    public class AesOperation  
    { 
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
        public static bool CheckEncrypted(string rawtext)
        {
            if (rawtext.Length >= 24)
            {
                // Check character
                byte[] rawBytes = Encoding.UTF8.GetBytes(rawtext);
                int vocalCharCount = 0;
                int otherCharCount = 0;
                int spaceCount = 0;
                int newLineCount = 0;
                int totalChar = rawBytes.Length;
                foreach (byte b in rawBytes)
                {
                    if (b == 10) newLineCount++;
                    else if (b == 32) spaceCount++;
                    // vocal upper 65 , 69 , 73 , 79 , 85
                    else if (b == 65 || b == 69 || b == 73 || b == 79 || b == 85) vocalCharCount++;
                    // vocal lower 97 , 101 , 105 , 111 , 117
                    else if (b == 97 || b == 101 || b == 105 || b == 111 || b == 117) vocalCharCount++;
                    else otherCharCount++;
                    
                }
                float vocalPercent = (vocalCharCount * 100 / totalChar) ;
                float spacePercent = (spaceCount * 100 / totalChar) ;
                float newLinePercent = (newLineCount * 100 / totalChar) ;
                float otherPercent = (otherCharCount * 100 / totalChar) ;
                // Check percetage text -----
                /*
                Console.WriteLine("Check Character count -----------------");
                Console.WriteLine("Vocal Percent : {0:F}", vocalPercent);
                Console.WriteLine("Space Percent : {0:F}", spacePercent);
                Console.WriteLine("New Line Percent : {0:F}", newLinePercent);
                Console.WriteLine("Other Percent : {0:F}", otherPercent);
                */
                /*
                Encrypted Text Criteria :
                * Vocal percent < 20
                * Space percent < 1
                * New line percent < 2
                */
                if (vocalPercent < 20 && (spacePercent < 1 || newLinePercent < 3)) return true;
                else return false;  
            }
            else return false;
        }
    }  
}  