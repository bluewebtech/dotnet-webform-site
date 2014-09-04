using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace dotnet_webform_site.classes
{

    public class Template
    {

        /**
	     * Array of opening and closing tags for escaped echos.
	     *
	     * @var string[]
	     */
        public static string[] contentTags = new string[] { "{", "}" };

        /**
	     * Array of opening and closing tags for escaped echos.
	     *
	     * @var string[]
	     */
        public static string[] escapedTags = new string[] { "{{", "}}" };

        /**
	     * View template file extension.
	     *
	     * @var string
	     */
        public static string extension = System.Configuration.ConfigurationManager.AppSettings["viewExtension"].ToString();

        /**
         * Return the compiled template
         * 
         * @param string file
         * 
         * return string
         */
        public static string compile(string view, Hashtable data = null)
        {
            var template = new List<string>();
            string path = Path.template() + view.Replace(".", @"\") + Template.extension;

            // Check if the view template specified exits.
            if (!File.Exists(path))
            {
                path = view.Replace(".", @"\") + Template.extension;
            }

            // Open up the view template.
            var file = Template.open(path);

            // Check is data was provided.
            if (data != null)
            {
                file = Template.compileComments(Template.compileData(file, data));
            }

            //System.Web.HttpContext.Current.Response.Write(Template.removeBlankLines(file));

            return Template.removeBlankLines(file);
        }

        /**
         * Remove all commented sections from the string.
         * 
         * @param string file
         * 
         * return string
         */
        public static string compileComments(string file = null)
        {
            var open    = Template.contentTags[0];
            var close   = Template.contentTags[1];
            var regex   = new Regex(@"(?<=\{--)(.*?)(?=\--})", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var matches = regex.Matches(file);

            foreach (var match in matches)
            {
                string item = match.ToString();
                file = file.Replace(open + "--" + item + "--" + close, "");
            }

            return file;
        }

        /**
         * Compile all single values.
         * 
         * @param string file
         * @param Hashtable data
         * 
         * return string
         */
        public static string compileData(string file = null, Hashtable data = null)
        {
            var open    = Template.contentTags[0];
            var close   = Template.contentTags[1];
            var regex   = new Regex(@"(?<=\{)(.*?)(?=\})", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            var matches = regex.Matches(file);

            foreach (object key in data.Keys)
            {
                foreach (var match in matches)
                {
                    string item = match.ToString();
                    file = file.Replace(open + key + close, data[key].ToString());
                }
            }

            return file;
        }

        /**
         * Return the view file as a string.
         * 
         * @param string file
         * 
         * return string
         */
        public static string open(string path)
        {
            using (var sr = new StreamReader(path, Encoding.Unicode))
            {
                return sr.ReadToEnd();
            }
        }

        /**
         * Compile the view.
         * 
         * @param string view
         * @param Hashtable data
         * 
         * return string
         */
        public static string make(string view, Hashtable data = null)
        {
            return Template.compile(view, data);
        }

        /**
         * Remove line break whitespace.
         * 
         * @param string file
         * 
         * return string
         */
        public static string removeBlankLines(String file = null)
        {
            return Regex.Replace(file, @"^\s+$[\r\n]*", "", RegexOptions.Multiline);
        }

        /**
         * Gets the path of the extends layout.
         * 
         * @param string layout
         * 
         * return string
         */
        public static string extendsPath(string layout)
        {
            string tag = "extends";
            string file = Template.open(Path.template() + layout.Replace(".", @"\") + Template.extension);
            string[] lines = Regex.Split(file, "\r\n");
            string fileName = "";

            if (lines.Length > 0)
            {
                string line = lines[0];
                line = Template.removeWhiteFromTag(line).Replace("'", "\"");
                string pattern = "{%" + tag + "\"(.*)\"%}";
                Regex regex = new Regex(pattern);
                var match = regex.Match(line);
                fileName = match.Groups[1].ToString();

                if (line == match.ToString())
                {
                    return fileName;
                }
            }

            return fileName;
        }

        /**
         * 
         * 
         * @param string layout
         * 
         * return string
         */
        public static string extendsFilePath(string layout)
        {
            return Path.layout() + layout.Replace(".", @"\");
        }

        /**
         * Checks if a extends layout file exists.
         * 
         * @param string layout
         * 
         * return Boolean
         */
        public static Boolean extendsFileExists(string layout)
        {
            if (File.Exists(layout))
            {
                return true;
            }

            return false;
        }

        /**
         * Checks whether the extends layout tag exists on the first line within the layout file.
         * 
         * @param string layout
         * 
         * return Boolean
         */
        public static Boolean extendsFirstLine(string layout)
        {
            string tag = "extends";
            string file = Template.open(Path.template() + layout.Replace(".", @"\") + Template.extension);
            string[] lines = Regex.Split(file, "\r\n");

            if (lines.Length > 0)
            {
                string line = lines[0];
                line = Template.removeWhiteFromTag(line).Replace("'", "\"");
                string pattern = "{%" + tag + "\"(.*)\"%}";
                Regex regex = new Regex(pattern);
                var match = regex.Match(line);
                string extends = match.Groups[1].ToString();

                if (line == match.ToString())
                {
                    return true;
                }                
            }

            return false;
        }

        /**
         * Return the extends layout template.
         * 
         * @param string view
         * 
         * return string
         */
        public static void extends(string view)
        {
            string layout = view;
            string fileName = Template.extendsPath(layout);
            string filePath = Template.extendsFilePath(fileName);

            if (Template.extendsFirstLine(layout))
            {
                //System.Web.HttpContext.Current.Response.Write(fileName + "<br />\n");
                //System.Web.HttpContext.Current.Response.Write(filePath + "<br />\n");
                System.Web.HttpContext.Current.Response.Write(Template.make(filePath));
            }
        }

        /**
         * Remove white space from tag.
         * 
         * @param string tag
         * 
         * return string
         */
        public static string removeWhiteFromTag(string tag)
        {
            return Strings.removeWhiteSpace(tag);
        }

    }

}