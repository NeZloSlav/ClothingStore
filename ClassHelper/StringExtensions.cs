using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Media.TextFormatting;

namespace ClothingStore.ClassHelper
{
    public static class StringExtensions
    {
        /// <summary>
        /// Проверяет введённую пользователем текстовую строку в поле "Номер телефона" на соответствие требованиям.
        /// </summary>
        /// <param name="phone"></param>
        /// <param name="IsRequired"></param>
        /// <returns></returns>
        public static bool ValidatePhoneNumber(this string phone, bool IsRequired)
        {
            if (string.IsNullOrEmpty(phone) & !IsRequired)
                return true;

            if (string.IsNullOrEmpty(phone) & IsRequired)
                return false;

            if (!phone.StartsWith("+7") & !phone.StartsWith("8") & !phone.StartsWith("7"))
                return false;

            var cleaned = phone.RemoveNonNumeric();

            if (IsRequired)
            {
                if (cleaned.Length == 11)
                    return true;
                else
                    return false;
            }
            else
            {
                if (cleaned.Length == 0)
                    return false;
                else if (cleaned.Length > 0 & cleaned.Length < 11)
                    return false;

                else if (cleaned.Length == 11)
                    return true;
                else
                    return false;

            }

        }

        /// <summary>
        /// Удаляет все не числовые значения из строки
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string RemoveNonNumeric(this string text)
        {
            return Regex.Replace(text, @"[^0-9]+", "");
        }


        /// <summary>
        /// Проверяет введённую пользователем текстовую строку в поле "Адрес эл. почты" на соответствие требованиям.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="IsRequired"></param>
        /// <returns></returns>
        public static bool ValidateEmailAddress(this string email, bool IsRequired)
        {
            if (string.IsNullOrEmpty(email) & !IsRequired)
                return true;

            if (string.IsNullOrEmpty(email) & IsRequired)
                return false;

            if (new EmailAddressAttribute().IsValid(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Проверяет введённый пользователем пароль на соответствие требованиям.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="IsRequired"></param>
        /// <returns></returns>
        public static bool ValidatePassword(this string password, bool IsRequired)
        {

            if (string.IsNullOrEmpty(password) & !IsRequired)
                return true;

            if (string.IsNullOrEmpty(password) & IsRequired)
                return false;

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


        /// <summary>
        /// Проверяет введённую пользователем текстовую строку в поля "Имя", "Фамилия" и тд. на соответствование требованиям.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="IsRequired"></param>
        /// <returns></returns>
        public static bool ValidateTextField(this string text, bool IsRequired)
        {
            if (string.IsNullOrEmpty(text) & !IsRequired)
                return true;

            if (string.IsNullOrEmpty(text) & IsRequired)
                return false;

            if (text.RemoveNonNumeric().Length > 0)
            {
                return false;
            }

            string specialChar = "\\/~!@#$%^&*()-_+={[]};:'\"|,<.>?";

            foreach (char c in specialChar)
            {
                if (text.Contains(c))
                    return false;
            }

            if (text.Length > 30)
            {
                return false;
            }

            return true;
        }

    }
}
