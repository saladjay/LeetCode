using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Q205 : IExecuteTest
    {
        public bool Test()
        {
            throw new NotImplementedException();
        }
        /*
         给定两个字符串 s 和 t，判断它们是否是同构的。

        如果 s 中的字符可以被替换得到 t ，那么这两个字符串是同构的。

        所有出现的字符都必须用另一个字符替换，同时保留字符的顺序。两个字符不能映射到同一个字符上，但字符可以映射自己本身。

        示例 1:

        输入: s = "egg", t = "add"
        输出: true
        示例 2:

        输入: s = "foo", t = "bar"
        输出: false
        示例 3:

        输入: s = "paper", t = "title"
        输出: true
        说明:
        你可以假设 s 和 t 具有相同的长度。

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/isomorphic-strings
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */

        public bool IsIsomorphic(string s, string t)
        {
            Dictionary<char, char> charDict1 = new Dictionary<char, char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (charDict1.ContainsKey(s[i]))
                {
                    if (charDict1[s[i]] != t[i])
                    {
                        return false;
                    }
                }
                else
                {
                    if (charDict1.ContainsValue(t[i]))
                    {
                        return false;
                    }
                    charDict1[s[i]] = t[i];
                }
            }
            return true;
        }
    }
}
