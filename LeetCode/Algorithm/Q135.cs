using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Q135 : IExecuteTest
    {
        public bool Test()
        {
            throw new NotImplementedException();
        }

        /*
         老师想给孩子们分发糖果，有 N 个孩子站成了一条直线，老师会根据每个孩子的表现，预先给他们评分。

        你需要按照以下要求，帮助老师给这些孩子分发糖果：

        每个孩子至少分配到 1 个糖果。
        相邻的孩子中，评分高的孩子必须获得更多的糖果。
        那么这样下来，老师至少需要准备多少颗糖果呢？

        示例 1:

        输入: [1,0,2]
        输出: 5
        解释: 你可以分别给这三个孩子分发 2、1、2 颗糖果。
        示例 2:

        输入: [1,2,2]
        输出: 4
        解释: 你可以分别给这三个孩子分发 1、2、1 颗糖果。
             第三个孩子只得到 1 颗糖果，这已满足上述两个条件。

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/candy
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */

        public int Candy(int[] ratings)
        {
            int[] candies = new int[ratings.Length];
            for (int i = 0; i < candies.Length; i++)
            {
                candies[i] = 1;
            }

            int left = 0, right = 0;
            int leftScore = 0, rightScore = 0;
            int leftCandies = 0, rightCandies = 0;
            for (int i = 0; i < candies.Length; i++)
            {
                left = i - 1;
                if (left < 0)
                {
                    leftCandies = 0;
                    leftScore = 0;
                }
                else
                {
                    leftCandies = candies[left];
                    leftScore = ratings[left];
                }

                if (ratings[i] > leftScore && candies[i] <= leftCandies)
                {
                    candies[i] = leftCandies + 1;
                }
            }

            for (int i = candies.Length-1; i >=0; i--)
            {
                right = i + 1;
                if (right >= candies.Length)
                {
                    rightCandies = 0;
                    rightScore = 0;
                }
                else
                {
                    rightCandies = candies[right];
                    rightScore = ratings[right];
                }

                if (ratings[i] > rightScore && candies[i] <= rightCandies)
                {
                    candies[i] = rightCandies + 1;
                }
            }
            int sum = 0;
            for (int i = 0; i < candies.Length; i++)
            {
                sum += candies[i];
            }
            return sum;
        }
    }
}
