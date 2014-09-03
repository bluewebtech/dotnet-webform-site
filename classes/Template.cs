using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet_webform_site.classes
{

    public class Template
    {

        /**
	     * Array of opening and closing tags for escaped echos.
	     *
	     * @var String[]
	     */
        public static String[] contentTags = new String[] { "{", "}" };

        /**
	     * Array of opening and closing tags for escaped echos.
	     *
	     * @var String[]
	     */
        public static String[] escapedTags = new String[] { "{{", "}}" };

        /**
	     * View template file extension.
	     *
	     * @var String
	     */
        public static String extension = System.Configuration.ConfigurationManager.AppSettings["viewExtension"].ToString();

        /**
         * Return the compiled template
         * 
         * @param String file
         * 
         * return String
         */
        public static String compile(String view, Hashtable data = null)
        {
            var template = new List<string>();
            String path = Path.template() + view.Replace(".", @"\") + Template.extension;
            var file = Template.open(path);

            file = Template.compileComments(Template.compileData(file, data));

            //System.Web.HttpContext.Current.Response.Write(Template.removeBlankLines(file));

            return Template.removeBlankLines(file);
        }

        /**
         * Remove all commented sections from the string.
         * 
         * @param String file
         * 
         * return String
         */
        public static String compileComments(String file = null)
        {
            var open    = Template.contentTags[0];
            var close   = Template.contentTags[1];
            var regex   = new Regex(@"(?<=\{--)(.*?)(?=\--})", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var matches = regex.Matches(file);

            foreach (var match in matches)
            {
                String item = match.ToString();
                file = file.Replace(open + "--" + item + "--" + close, "");
            }

            return file;
        }

        /**
         * Compile all single values.
         * 
         * @param String file
         * @param Hashtable data
         * 
         * return String
         */
        public static String compileData(String file = null, Hashtable data = null)
        {
            var open    = Template.contentTags[0];
            var close   = Template.contentTags[1];
            var regex   = new Regex(@"(?<=\{)(.*?)(?=\})", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var matches = regex.Matches(file);

            foreach (object key in data.Keys)
            {
                foreach (var match in matches)
                {
                    String item = match.ToString();
                    file = file.Replace(open + key + close, data[key].ToString());
                }
            }

            return file;
        }

        /**
         * Return the view file as a string.
         * 
         * @param String file
         * 
         * return String
         */
        public static String open(String path)
        {
            using (var sr = new StreamReader(path, Encoding.Unicode))
            {
                return sr.ReadToEnd();
            }
        }

        /**
         * Compile the view.
         * 
         * @param String view
         * @param Hashtable data
         * 
         * return String
         */
        public static String make(String view, Hashtable data = null)
        {
            return Template.compile(view, data);
        }

        /**
         * Remove line break whitespace.
         * 
         * @param String file
         * 
         * return String
         */
        public static String removeBlankLines(String file = null)
        {
            return Regex.Replace(file, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
        }

    }

}