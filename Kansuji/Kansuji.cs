using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kansuji
{
    public class Kansuji
    {
        private Dictionary<string, int> scales = new Dictionary<string, int> {
            {"十", 1}, {"百", 2}, {"千", 3}
        };

        private Dictionary<string, int> largeNumerals = new Dictionary<string, int> {
            {"万", 4}, {"億", 8}, {"兆", 12}, {"京", 16}, {"垓", 20}, {"𥝱", 24},
            {"穣", 28}, {"溝", 32}, {"澗", 36}, {"正", 40}, {"載", 44}, {"極", 48},
            {"恒河沙", 52}, {"阿僧祇", 56}, {"那由他", 60}, {"不可思議", 64}, {"無量大数", 68}
        };

        private string basePattern = "十|百|千|万|億|兆|京|垓|𥝱|穣|溝|澗|正|載|極|恒河沙|阿僧祇|那由他|不可思議|無量大数";
        private string extractPattern = @"(\d|十|百|千|万)?(\d|{0})*(!?\d|{0})";
        private string parsePattern = @"(\d+|\d?)({0})?";
        private string detectPattern = @"({0})";

        /// <summary>
        /// 漢数字を半角数字に置換します。
        /// </summary>
        /// <param name="str">置換する文字列</param>
        public void ReplaceKansujiToNumber(ref StringBuilder sb, bool wide, bool commaSeparated)
        {
            ReplaceWideNumber(ref sb);
            ReplaceDaiji(ref sb);
            ReplaceTaisu(ref sb);
            ReplaceCompund(ref sb);
            ReplaceNumber(ref sb);

            if (HasScaleOrTaisu(sb.ToString()))
            {
                IEnumerable<string> matches = Regex.Matches(sb.ToString(), string.Format(extractPattern, basePattern))
                    .OfType<Match>().Select(m => m.Groups[0].Value).Distinct();

                foreach (string match in matches)
                {
                    string result = ConvertKansujiToNumber(match);

                    if (result.Length > 1 && result.IndexOf('0') == 0)
                    {
                        continue;
                    }

                    sb.Replace(match, result);
                }
            }

            if(commaSeparated)
            {

            }

            if(wide)
            {
                ReplaceToWideNumber(ref sb);
            }
        }

        /// <summary>
        /// 位か大数が存在するか判定します。
        /// </summary>
        /// <param name="str">判定する文字列</param>
        /// <returns>判定結果</returns>
        private bool HasScaleOrTaisu(string str)
        {
            return Regex.IsMatch(str, string.Format(detectPattern, basePattern));
        }

        /// <summary>
        /// 漢数字を数字に変換します。
        /// </summary>
        /// <param name="str">変換する文字列</param>
        /// <returns>変換した文字列</returns>
        private string ConvertKansujiToNumber(string str)
        {
            string result = "";
            int targetDigit = 0;

            if (!HasScaleOrTaisu(str))
            {
                targetDigit = str.Length;
            }

            MatchCollection matches = Regex.Matches(str, string.Format(parsePattern, basePattern));

            int subtotal = 0;
            List<Array> total = new List<Array>();

            for (int i = 0; i < matches.Count - 1; i++)
            {
                int number = 0;
                int scale = 0;
                int largeNumeral = 0;

                Match match = matches[i];

                if (string.IsNullOrEmpty(match.Value))
                {
                    break;
                }

                string value = match.Value;

                if (value.Length > 1)
                {
                    string tmp = value;

                    if (char.IsDigit(value[0]))
                    {
                        int digitLength = 0;

                        foreach(char c in value)
                        {
                            if(char.IsDigit(c))
                            {
                                digitLength++;
                            }
                        }

                        number = int.Parse(value.Substring(0, digitLength));
                        tmp = value.Substring(digitLength);
                    }

                    if (scales.ContainsKey(tmp))
                    {
                        scale = scales[tmp];
                    }
                    else if(!string.IsNullOrEmpty(tmp))
                    {
                        largeNumeral = largeNumerals[tmp];
                    }
                }
                else if (scales.ContainsKey(value) || largeNumerals.ContainsKey(value))
                {
                    if (scales.ContainsKey(value))
                    {
                        number = 1;
                        scale = scales[value];
                    }
                    else
                    {
                        largeNumeral = largeNumerals[value];
                    }
                }
                else
                {
                    number = int.Parse(value);

                    if (targetDigit > 0)
                    {
                        scale = targetDigit - 1;
                        targetDigit--;
                    }
                }

                if (largeNumeral == 0)
                {
                    subtotal += number * (int)Math.Pow(10, scale);

                    if (i == matches.Count - 2)
                    {
                        total.Add(new int[] { subtotal, largeNumeral });
                        break;
                    }
                }
                else
                {
                    subtotal += number;
                    total.Add(new int[] { subtotal, largeNumeral });
                    subtotal = 0;
                }
            }

            for (int i = total.Count - 1; i > -1; i--)
            {
                result = ((int[])total[i])[0].ToString() + result.PadLeft(((int[])total[i])[1], '0');
            }

            return result;
        }

        /// <summary>
        /// 同じ意味の違う大数に置換します。
        /// </summary>
        /// <param name="sb">置換する文字列</param>
        private void ReplaceTaisu(ref StringBuilder sb)
        {
            sb.Replace("秭", "𥝱");
        }

        /// <summary>
        /// 大字を漢数字に置換します。
        /// </summary>
        /// <param name="sb">置換する文字列</param>
        private void ReplaceDaiji(ref StringBuilder sb)
        {
            sb
                .Replace("零", "〇")
                .Replace("壱", "一")
                .Replace("弐", "二")
                .Replace("参", "三")
                .Replace("伍", "五")
                .Replace("拾", "十")
                .Replace("萬", "万");
        }

        /// <summary>
        /// 複合字を漢数字に置換します。
        /// </summary>
        /// <param name="sb">置換する文字列</param>
        private void ReplaceCompund(ref StringBuilder sb)
        {
            sb
                .Replace("廿", "二十")
                .Replace("卄", "二十")
                .Replace("卅", "三十")
                .Replace("丗", "三十")
                .Replace("卌", "四十");
        }

        /// <summary>
        /// 漢数字を半角数字に置換します。
        /// </summary>
        /// <param name="sb">置換する文字列</param>
        private void ReplaceNumber(ref StringBuilder sb)
        {
            sb
                .Replace("〇", "0")
                .Replace("一", "1")
                .Replace("二", "2")
                .Replace("三", "3")
                .Replace("四", "4")
                .Replace("五", "5")
                .Replace("六", "6")
                .Replace("七", "7")
                .Replace("八", "8")
                .Replace("九", "9");
        }

        /// <summary>
        /// 半角数字を全角数字に置換します。
        /// </summary>
        /// <param name="sb">置換する文字列</param>
        private void ReplaceToWideNumber(ref StringBuilder sb)
        {
            sb
                .Replace("0", "０")
                .Replace("1", "１")
                .Replace("2", "２")
                .Replace("3", "３")
                .Replace("4", "４")
                .Replace("5", "５")
                .Replace("6", "６")
                .Replace("7", "７")
                .Replace("8", "８")
                .Replace("9", "９")
                .Replace(",", "，");
        }

        /// <summary>
        /// 全角数字を半角数字に置換します。
        /// </summary>
        /// <param name="sb">置換する文字列</param>
        private void ReplaceWideNumber(ref StringBuilder sb)
        {
            sb
                .Replace("０", "0")
                .Replace("１", "1")
                .Replace("２", "2")
                .Replace("３", "3")
                .Replace("４", "4")
                .Replace("５", "5")
                .Replace("６", "6")
                .Replace("７", "7")
                .Replace("８", "8")
                .Replace("９", "9");
        }
    }
}
