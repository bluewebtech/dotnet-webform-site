using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet_webform_site.classes
{

    public class Format
    {

        /**
         * Return a lower cased string.
         * 
         * @param string param
         * 
         * return string
         */
        public static string lowerCase(string param = null)
        {
            return param.ToLower();
        }

        /**
         * Return string with the first letter lower cased.
         * 
         * @param string param
         * 
         * return string
         */
        public static string lowerCaseFirst(string param = null)
        {
            return char.ToLower(param[0]) + param.Substring(1);
        }

        /**
         * Return a formatted telephone number.
         * 
         * @param string param
         * 
         * return string
         */
        public static string telephone(string param = null)
        {
            return String.Format("{0:(###) ###-####}", param);
        }

        /**
         * Return a upper case string.
         * 
         * @param string param
         * 
         * return string
         */
        public static string upperCase(string param = null)
        {
            return param.ToUpper();
        }

        /**
         * Return string with the first letter upper cased.
         * 
         * @param string param
         * 
         * return string
         */
        public static string upperCaseFirst(string param = null)
        {
            return char.ToUpper(param[0]) + param.Substring(1);
        }

        /**
         * Return string with the first letter of each word upper cased.
         * 
         * @param string param
         * 
         * return string
         */
        public static string upperCaseWords(string param = null)
        {
            // This API path is simply ridiculous.
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(param.ToLower());
        }

    }

}