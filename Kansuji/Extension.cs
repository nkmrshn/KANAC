using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kansuji
{
    public static class Extension
    {
        /// <summary>
        /// 漢数字を半角数字に置換します。
        /// </summary>
        /// <param name="str">置換する文字列</param>
        /// <param name="wide">全角数字に置換する</param>
        /// <returns>置換した文字列</returns>    
        public static string ReplaceKansujiToNumber(this string str, bool wide = false)
        {
            StringBuilder sb = new StringBuilder(str);
            Kansuji kansuji = new Kansuji();

            if (wide)
            {
                kansuji.ReplaceKansujiToWideNumber(ref sb);
            }
            else
            {
                kansuji.ReplaceKansujiToNumber(ref sb);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 漢数字を全角数字に置換します。
        /// </summary>
        /// <param name="str">置換する文字列</param>
        /// <returns>置換した文字列</returns>
        public static string ReplaceKansujiToWideNumber(this string str)
        {
            return ReplaceKansujiToNumber(str, true);
        }
    }
}
