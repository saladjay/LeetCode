using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Q387 : IExecuteTest
    {
        public bool Test()
        {
            throw new NotImplementedException();
        }

        /*
        给定一个字符串，找到它的第一个不重复的字符，并返回它的索引。如果不存在，则返回 -1。

 

        示例：

        s = "leetcode"
        返回 0

        s = "loveleetcode"
        返回 2
 

        提示：你可以假定该字符串只包含小写字母。
         */

        public int FirstUniqChar(string s)
        {
            int[] charArray = new int[26];
            foreach (var c in s)
            {
                var index = c - 'a';
                charArray[index] += 1;
            }
            for (int i = 0; i < s.Length; i++)
            {                var index = s[i] - 'a';
                if (charArray[index] == 1)
                    return i;
            }
            return -1;
        }

        public int FirstUniqCharFast(string s)
        {
            int[] charArray = new int['z' + 1];
            foreach (var c in s)
            {
                charArray[c] += 1;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (charArray[s[i]] == 1)
                    return i;
            }
            return -1;
        }
    }
}
