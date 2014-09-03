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
         * @param String param
         * 
         * return String
         */
        public static String lowerCase(String param = null)
        {
            return param.ToLower();
        }

        /**
         * Return string with the first letter lower cased.
         * 
         * @param String param
         * 
         * return String
         */
        public static string lowerCaseFirst(String param = null)
        {
            return char.ToLower(param[0]) + param.Substring(1);
        }

        /**
         * Return a formatted telephone number.
         * 
         * @param String param
         * 
         * return String
         */
        public static String telephone(String param = null)
        {
            return String.Format("{0:(###) ###-####}", param);
        }

        /**
         * Return a upper case string.
         * 
         * @param String param
         * 
         * return String
         */
        public static String upperCase(String param = null)
        {
            return param.ToUpper();
        }

        /**
         * Return string with the first letter upper cased.
         * 
         * @param String param
         * 
         * return String
         */
        public static string upperCaseFirst(String param = null)
        {
            return char.ToUpper(param[0]) + param.Substring(1);
        }

        /**
         * Return string with the first letter of each word upper cased.
         * 
         * @param String param
         * 
         * return String
         */
        public static string upperCaseWords(String param = null)
        {
            // This API path is simply ridiculous.
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(param.ToLower());
        }

    }

}