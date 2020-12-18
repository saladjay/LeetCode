using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Q389 : IExecuteTest
    {
        public bool Test()
        {
            var res1 = FindTheDifference("abcd", "abcde") == 'e';
            var res2 = FindTheDifference("", "y") == 'y';
            var res3 = FindTheDifference("a", "aa") == 'a';
            var res4 = FindTheDifference("ae", "aea") == 'a';
            return res1 & res2 & res3 & res4;
        }

        /*
        给定两个字符串 s 和 t，它们只包含小写字母。

        字符串 t 由字符串 s 随机重排，然后在随机位置添加一个字母。

        请找出在 t 中被添加的字母。

 

        示例 1：

        输入：s = "abcd", t = "abcde"
        输出："e"
        解释：'e' 是那个被添加的字母。
        示例 2：

        输入：s = "", t = "y"
        输出："y"
        示例 3：

        输入：s = "a", t = "aa"
        输出："a"
        示例 4：

        输入：s = "ae", t = "aea"
        输出："a"
 

        提示：

        0 <= s.length <= 1000
        t.length == s.length + 1
        s 和 t 只包含小写字母

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/find-the-difference
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
        */

        public char FindTheDifference(string s, string t)
        {
            var res = (char)0;

            foreach (var c in s)
            {
                res ^= c;
            }
            foreach (var c in t)
            {
                res ^= c;
            }

            return res;
        }

        public char FindTheDifferenceBestAnswear(string s, string t)
        {
            var res = t[t.Length-1];

            for (int i = 0; i < s.Length; i++)
            {
                res ^= s[i];
                res ^= t[i];
            }

            return res;
        }
    }
}
