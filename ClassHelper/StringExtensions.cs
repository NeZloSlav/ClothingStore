using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClothingStore.ClassHelper
{
    public static class StringExtensions
    {
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool ValidatePhoneNumber(this string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return false;

            var cleaned = phone.RemoveNonNumeric();

            if (cleaned.StartsWith("7") || cleaned.StartsWith("8"))
            {
                if (cleaned.Length == 11)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
           

        }

        /// <summary>
        /// Removes all non numeric characters from a string
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static string RemoveNonNumeric(this string phone)
        {
            return Regex.Replace(phone, @"[^0-9]+", "");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ValidatePassword(this string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }
            else
            {
                if (password.Any(c => !char.IsLetterOrDigit(c)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            

        }

    }
}
