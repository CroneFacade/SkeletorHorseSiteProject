using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace SkeletorDAL.Helpers
{
    public static class StringExtensions
    {
        public static string SuperHash(this string source)
        {
            // Adding salt like a Swede
            source += @"vìª½¨'ÍÙþüåtÑ%­qjâ`âAõ¹·--3XYUé/~Hm1&¿þtQ°ë<½Îu®H";
            // This is the string we will be generating the computed password too
            string funnyString = "";
            // We're using SHA512 for our initial hash of the password
            // (SHA512 because stackoverflow said so)
            using (SHA512 sha512Hash = SHA512.Create())
            {
                // Hashing using SHA512
                funnyString = GetShaHash(sha512Hash, source);
                string tempString = funnyString;
                funnyString = "";
                // Here we are disguising what kind of hash we used by
                // completely Super screwing the string
                for (int i = 0; i < 20; i++)
                {
                    // re-hashing previous result and retrieving a
                    // byte array to manipulate further
                    byte[] data = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(tempString));
                    foreach (var item in data)
                    {
                        if (item > 32)
                        {
                            // Converting the byte array to a string of ASCII chars
                            funnyString += (char)item;
                        }
                    }
                    tempString = funnyString;
                }
                // Return the funny string
                return funnyString;
            }
        }
        static string GetShaHash(SHA512 sha512Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash. 
            byte[] data = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }
    }
}