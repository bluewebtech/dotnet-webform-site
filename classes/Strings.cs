using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace dotnet_webform_site.classes
{

    public class Strings
    {

        /**
         * Remove all whitespace from string.
         * 
         * @param string param
         * 
         * return string
         */
        public static string removeWhiteSpace(string param)
        {
            return Regex.Replace(param, @"\s+", "");
        }

    }

}