using System;

namespace CompanyTool
{
    public class KeyName
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");
        }

        public static string GetKeyName(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                return name.Trim().Replace("~", "-").Replace("`", "-").Replace("!", "-").Replace("@", "-")
                    .Replace("#", "-").Replace("$", "-").Replace("%", "-").Replace("^", "-").Replace("&", "-").Replace("*", "-")
                    .Replace(" ", "-").Replace("(", "-").Replace(")", "-").Replace("+", "-").Replace("®", "-").Replace("™", "-")
                    .Replace("=", "-").Replace(",", "-").Replace(".", "-").Replace("<", "-").Replace(">", "-").Replace("’", "-").Replace("，", "-").Replace("±", "-").Replace("[", "-").Replace("]", "-")
                    .Replace("?", "-").Replace("/", "-").Replace("\\", "-").Replace(";", "-").Replace(":", "-").Replace("–", "-").Replace("ω", "-").Replace("{", "-").Replace("}", "-")
                    .Replace("'", "-").Replace("\"", "-").Replace("“", "-").Replace("”", "-").Replace("|", "-").Replace("_", "-").Replace("---", "-").Replace("--", "-").ToLower().Trim();
            }
            return "";
        }

    }
}
