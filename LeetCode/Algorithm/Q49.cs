using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Q49 : IExecuteTest
    {
        public bool Test()
        {
            var res = GroupAnagrams(new string[] { "eat", "tea", "tan", "ate", "nat", "bat" });
            HashSet<HashSet<string>> answear = new HashSet<HashSet<string>>();
            foreach (var strs in res)
            {
                var strs_hashSet = new HashSet<string>();
                foreach (var str in strs)
                {
                    strs_hashSet.Add(str);
                }
                answear.Add(strs_hashSet);
            }
            
            var correct = new HashSet<HashSet<string>>() { new HashSet<string>() { "ate", "eat", "tea" },
                new HashSet<string>(){ "nat", "tan" },new HashSet<string>(){ "bat"}            };
            var isCorrect = true;
            foreach (var item in answear)
            {
                var subSetCorrect = false;
                foreach (var item1 in correct)
                {
                    subSetCorrect |= item.SetEquals(item1);
                }
                isCorrect &= subSetCorrect;
            }
            return isCorrect;
        }

        /*
         给定一个字符串数组，将字母异位词组合在一起。字母异位词指字母相同，但排列不同的字符串。

        示例:

        输入: ["eat", "tea", "tan", "ate", "nat", "bat"]
        输出:
        [
          ["ate","eat","tea"],
          ["nat","tan"],
          ["bat"]
        ]
        说明：

        所有输入均为小写字母。
        不考虑答案输出的顺序。

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/group-anagrams
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */

        public IList<IList<string>> MyGroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> res_dict = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var c_list = new List<int>();
                foreach (var c in str)
                {
                    c_list.Add(c);
                }
                c_list.Sort();
                //List<int>可以用charArray替换加速。
                StringBuilder sb = new StringBuilder();
                foreach (var cc in c_list)
                {
                    sb.Append(cc);
                }
                var key = sb.ToString();
                //用字符串制作key，可以用string的构造方法。 
                if (res_dict.ContainsKey(key))
                {
                    res_dict[key].Add(str);
                }
                else
                {
                    res_dict[key] = new List<string>() { str };
                }
            }
            IList<IList<string>> vs = new List<IList<string>>();
            foreach (var value in res_dict.Values)
            {
                vs.Add(value);
            }
            //字典的values和keys可以转成IList<T>输出。
            return vs;
        }

        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> res_dict = new Dictionary<string, IList<string>>();
            foreach (var str in strs)
            {
                var c_list = str.ToCharArray();
                Array.Sort(c_list);
                var key = new string(c_list);

                if (!res_dict.ContainsKey(key))
                {
                    res_dict[key] = new List<string>();
                }
                res_dict[key].Add(str);
            }
            return res_dict.Values.ToList();
        }
    }
}
