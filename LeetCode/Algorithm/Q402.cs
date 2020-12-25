using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Q402 : IExecuteTest
    {
        public bool Test()
        {
            throw new NotImplementedException();
        }

        /*
         给定一个以字符串表示的非负整数 num，移除这个数中的 k 位数字，使得剩下的数字最小。

        注意:

        num 的长度小于 10002 且 ≥ k。
        num 不会包含任何前导零。
        示例 1 :

        输入: num = "1432219", k = 3
        输出: "1219"
        解释: 移除掉三个数字 4, 3, 和 2 形成一个新的最小的数字 1219。
        示例 2 :

        输入: num = "10200", k = 1
        输出: "200"
        解释: 移掉首位的 1 剩下的数字为 200. 注意输出不能有任何前导零。
        示例 3 :

        输入: num = "10", k = 2
        输出: "0"
        解释: 从原数字移除所有的数字，剩余为空就是0。

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/remove-k-digits
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */

        public string RemoveKdigits(string num, int k)
        {
            StringBuilder sb = new StringBuilder(num);
            if (num.Length < 1 || num.Length == k)
            {
                return "0";
            }
            int dropCount = 0;
            int index = 1;
            while (index < sb.Length && dropCount < k)
            {
                if (sb[index - 1] > sb[index])
                {
                    sb.Remove(index - 1, 1);
                    dropCount++;
                    index--;
                    if (index < 1)
                    {
                        index = 1;
                    }
                }
                else
                {
                    index++;
                }
            }

            if (dropCount < k)
            {
                sb.Remove(sb.Length - (k - dropCount), (k - dropCount));
            }

            while (sb.Length > 1 && sb[0] == '0')
            {
                sb.Remove(0, 1);
            }
            return sb.ToString();
        }
    }
}
