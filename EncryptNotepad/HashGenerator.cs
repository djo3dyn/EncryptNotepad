using System;  
using System.IO;  
using System.Security.Cryptography;  
using System.Text;  
  
namespace EncryptDecryptSymetric 
{  
    public class HashGenerator  
    {
        public static byte[] ComputeSha256Hash(string rawData)  
        {  
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return bytes;
            }  
        }

        public static byte[] ComputeSha128Hash(string rawData)  
        {  
            // Create a SHA256   
            using (SHA1 sha1Hash = SHA1.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = sha1Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return bytes;
            }  
        }

        public static byte[] ComputeMD5Hash(string rawData)  
        {  
            // Create a SHA256   
            using (MD5 md5Hash = MD5.Create())  
            {  
                // ComputeHash - returns byte array  
                byte[] bytes = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                return bytes;
            }  
        }
    }
}    