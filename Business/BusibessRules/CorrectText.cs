using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusibessRules
{
    public static class CorrectText
    {
        public static string Correct(this string text)
        {
            text = text.TrimStart(new Char[] { ' ', '*', '.', '!', ',', '?' });
            text = text.TrimEnd(new Char[] { ' ', '*', ',' });
            while (text.Contains("  ")) { text = text.Replace("  ", " "); }
            text = text.Replace(" ,", ",");
            text = text.Replace(" !", "!");
            text = text.Replace(" .", ".");
            text = text.Replace(" ;", ";");
            text = text.Replace(" :", ":");
            text = text.Replace(" ?", "?");
            for (int i = 0; i < text.Length; i++)
            {
                if (i != text.Length - 1 && char.IsPunctuation(text[i]) && !char.IsWhiteSpace(text[i]) && text[i + 1] != ' ')
                {
                    int a = i + 1;
                    while ((a <= text.Length - 1) && !char.IsLetter(text[a]))
                    {
                        a++;
                    }
                    string newString1 = text.Substring(a, text.Length - a);
                    string newString2 = text.Substring(0, i + 1);
                    StringBuilder str = new StringBuilder();
                    str.Append(newString2);
                    str.Append(" ");
                    str.Append(newString1);
                    text = str.ToString();
                    i = 0;
                }
            }
            text = text.Trim();
            StringBuilder str1 = new StringBuilder();
            str1.Append(text);
            str1[0] = char.ToUpper(str1[0]);
            for (int i = 0; i < str1.Length; i++)
            {
                if ((i <= str1.Length - 3) && (text[i] == '.' || text[i] == '?' || text[i] == '!') && str1[i + 1] == ' ' && !char.IsUpper(str1[i + 2]))
                {
                    str1[i + 2] = char.ToUpper(str1[i + 2]);
                }
            }
            if (str1[str1.Length - 1] == ',' || str1[str1.Length - 1] == ':' || str1[str1.Length - 1] == ';' || str1[str1.Length - 1] == '-' || str1[str1.Length - 1] == ' ') str1[str1.Length - 1] = '.';
            if (char.IsLetter(str1[str1.Length - 1])) str1.Append(".");
            text = str1.ToString();
            return text;
        }
    }
}
