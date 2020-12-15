using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Q738 : IExecuteTest
    {
        public bool Test()
        {
            var res1 = MonotoneIncreasingDigits(10) == 9;
            var res2 = MonotoneIncreasingDigits(1234) == 1234;
            var res3 = MonotoneIncreasingDigits(332) == 299;
            var res4 = MonotoneIncreasingDigits(121) == 119;
            return res1 & res2 & res3 & res4;
        }

        /*
         给定一个非负整数 N，找出小于或等于 N 的最大的整数，同时这个整数需要满足其各个位数上的数字是单调递增。

        （当且仅当每个相邻位数上的数字 x 和 y 满足 x <= y 时，我们称这个整数是单调递增的。）

        示例 1:

        输入: N = 10
        输出: 9
        示例 2:

        输入: N = 1234
        输出: 1234
        示例 3:

        输入: N = 332
        输出: 299
        说明: N 是在 [0, 10^9] 范围内的一个整数。

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/monotone-increasing-digits
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */

        public int MonotoneIncreasingDigits(int N)
        {
            string numStr = N.ToString();
            Queue<char> numStack = new Queue<char>();
            var flag = true;
            foreach (var c in numStr)
            {
                var int_c = c;
                if ((numStack.Count == 0 || numStack.Last() <= int_c) && flag)
                {
                    numStack.Enqueue(int_c);
                }
                else
                {
                    flag = false;
                    numStack.Enqueue('0');
                }
            }
            if (flag)
            {
                return N;
            }
            var sb = new StringBuilder();
            while (numStack.Count > 0)
            {
                sb.Append(numStack.Dequeue());
            }
            return MonotoneIncreasingDigits(int.Parse(sb.ToString()) - 1);
        }

        public int MonotoneIncreasingDigitsBest(int N)
        {
            int divisor = 1;
            while (divisor<N)
            {
                var remainder = N / divisor % 100;
                var tens = remainder / 10;
                var units = remainder % 10;
                divisor *= 10;
                if (tens > units)
                {
                    N = N / divisor * divisor - 1;
                }
            }
            return N;
        }
    }
}
