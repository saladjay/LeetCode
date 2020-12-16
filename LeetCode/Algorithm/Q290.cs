using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Q290 : IExecuteTest
    {
        public bool Test()
        {
            var res1 = WordPattern("abba", "dog cat cat dog");
            var res2 = WordPattern("abba", "dog cat cat fish");
            var res3 = WordPattern("aaaa", "dog cat cat dog");
            var res4 = WordPattern("abba", "dog dog dog dog");
            return res1 & res2 & res3 & res4;
        }

        /*
        给定一种规律 pattern 和一个字符串 str ，判断 str 是否遵循相同的规律。

        这里的 遵循 指完全匹配，例如， pattern 里的每个字母和字符串 str 中的每个非空单词之间存在着双向连接的对应规律。

        示例1:

        输入: pattern = "abba", str = "dog cat cat dog"
        输出: true
        示例 2:

        输入:pattern = "abba", str = "dog cat cat fish"
        输出: false
        示例 3:

        输入: pattern = "aaaa", str = "dog cat cat dog"
        输出: false
        示例 4:

        输入: pattern = "abba", str = "dog dog dog dog"
        输出: false
        说明:
        你可以假设 pattern 只包含小写字母， str 包含了由单个空格分隔的小写字母。    

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/word-pattern
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */

        public bool WordPattern(string pattern, string s)
        {
            Dictionary<char, string> CharToString = new Dictionary<char, string>();
            Dictionary<string, char> StringToChar = new Dictionary<string, char>();

            var strsArray = s.Split(' ');
            if (strsArray.Length != pattern.Length)
            {
                return false;
            }
            for (int i = 0; i < pattern.Length; i++)
            {
                var c = pattern[i];
                var str = strsArray[i];
                if (CharToString.ContainsKey(c) && CharToString[c] != str)
                {
                    return false;
                }
                if (CharToString.ContainsKey(c) == false)
                {
                    CharToString[c] = str;
                }

                if (StringToChar.ContainsKey(str) && StringToChar[str] != c)
                {
                    return false;
                }
                if (StringToChar.ContainsKey(str) == false)
                {
                    StringToChar[str] = c;
                }
            }
            return true;
        }
    }
}
