using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.WeeklyMatch
{
    public class Week219 : IExecuteTest
    {
        public bool Test()
        {
            var res1 = NumberOfMatches(7) == 6;
            var res2 = NumberOfMatches(14) == 13;


            return res1 & res2;
        }
        /*
         给你一个整数 n ，表示比赛中的队伍数。比赛遵循一种独特的赛制：

        如果当前队伍数是 偶数 ，那么每支队伍都会与另一支队伍配对。总共进行 n / 2 场比赛，且产生 n / 2 支队伍进入下一轮。
        如果当前队伍数为 奇数 ，那么将会随机轮空并晋级一支队伍，其余的队伍配对。总共进行 (n - 1) / 2 场比赛，且产生 (n - 1) / 2 + 1 支队伍进入下一轮。
        返回在比赛中进行的配对次数，直到决出获胜队伍为止。

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/count-of-matches-in-tournament
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */
        public int NumberOfMatches(int n)
        {
            if (n == 1)
            {
                return 0;
            }
            if (n == 2)
            {
                return 1;
            }
            if (n % 2 == 0)
            {
                return n / 2 + NumberOfMatches(n / 2);
            }
            else
            {
                return (n - 1) / 2 + NumberOfMatches((n - 1) / 2 + 1);
            }
        }
        /*
         如果一个十进制数字不含任何前导零，且每一位上的数字不是 0 就是 1 ，那么该数字就是一个 十-二进制数 。例如，101 和 1100 都是 十-二进制数，而 112 和 3001 不是。

        给你一个表示十进制整数的字符串 n ，返回和为 n 的 十-二进制数 的最少数目。

 

        示例 1：

        输入：n = "32"
        输出：3
        解释：10 + 11 + 11 = 32
        示例 2：

        输入：n = "82734"
        输出：8
        示例 3：

        输入：n = "27346209830709182346"
        输出：9

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/partitioning-into-minimum-number-of-deci-binary-numbers
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
                 */
        public int MinPartitions(string n)
        {
            var maxNum = 0;
            foreach (var c in n)
            {
                int value = 0;
                switch (c)
                {
                    case '0':
                        value = 0;
                        break;
                    case '1':
                        value = 1;
                        break;
                    case '2':
                        value = 2;
                        break;
                    case '3':
                        value = 3;
                        break;
                    case '4':
                        value = 4;
                        break;
                    case '5':
                        value = 5;
                        break;
                    case '6':
                        value = 6;
                        break;
                    case '7':
                        value = 7;
                        break;
                    case '8':
                        value = 8;
                        break;
                    case '9':
                        value = 9;
                        break;
                    default:
                        break;
                }
                if (value > maxNum)
                {
                    maxNum = value;
                }
                if (maxNum == 9)
                {
                    return maxNum;
                }
            }
            return maxNum;
        }
        /*
         石子游戏中，爱丽丝和鲍勃轮流进行自己的回合，爱丽丝先开始 。

        有 n 块石子排成一排。每个玩家的回合中，可以从行中 移除 最左边的石头或最右边的石头，并获得与该行中剩余石头值之 和 相等的得分。当没有石头可移除时，得分较高者获胜。

        鲍勃发现他总是输掉游戏（可怜的鲍勃，他总是输），所以他决定尽力 减小得分的差值 。爱丽丝的目标是最大限度地 扩大得分的差值 。

        给你一个整数数组 stones ，其中 stones[i] 表示 从左边开始 的第 i 个石头的值，如果爱丽丝和鲍勃都 发挥出最佳水平 ，请返回他们 得分的差值 。

 

        示例 1：

        输入：stones = [5,3,1,4,2]
        输出：6
        解释：
        - 爱丽丝移除 2 ，得分 5 + 3 + 1 + 4 = 13 。游戏情况：爱丽丝 = 13 ，鲍勃 = 0 ，石子 = [5,3,1,4] 。
        - 鲍勃移除 5 ，得分 3 + 1 + 4 = 8 。游戏情况：爱丽丝 = 13 ，鲍勃 = 8 ，石子 = [3,1,4] 。
        - 爱丽丝移除 3 ，得分 1 + 4 = 5 。游戏情况：爱丽丝 = 18 ，鲍勃 = 8 ，石子 = [1,4] 。
        - 鲍勃移除 1 ，得分 4 。游戏情况：爱丽丝 = 18 ，鲍勃 = 12 ，石子 = [4] 。
        - 爱丽丝移除 4 ，得分 0 。游戏情况：爱丽丝 = 18 ，鲍勃 = 12 ，石子 = [] 。
        得分的差值 18 - 12 = 6 。
        示例 2：

        输入：stones = [7,90,5,1,100,10,10,2]
        输出：122

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/stone-game-vii
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */
        public int stoneGameVII(int[] stones)
        {
            throw new Exception();
        }
    }
}
