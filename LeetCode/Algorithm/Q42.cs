using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Q42 : IExecuteTest
    {
        public bool Test()
        {
            var res1 = Trap3(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }) == 6;
            var res2 = Trap3(new int[] { 4, 2, 0, 3, 2, 5 }) == 9;
            return res1 & res2;
        }

        /*
         给定 n 个非负整数表示每个宽度为 1 的柱子的高度图，计算按此排列的柱子，下雨之后能接多少雨水。

        示例 1：
        输入：height = [0,1,0,2,1,0,1,3,2,1,2,1]
        输出：6
        解释：上面是由数组 [0,1,0,2,1,0,1,3,2,1,2,1] 表示的高度图，在这种情况下，可以接 6 个单位的雨水（蓝色部分表示雨水）。 
        示例 2：

        输入：height = [4,2,0,3,2,5]
        输出：9

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/trapping-rain-water
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */
        public int Trap(int[] height)
        {
            Stack<int> heightStack = new Stack<int>();
            Stack<int> subHeightStack = new Stack<int>();
            int total = 0;
            foreach (var h in height)
            {
                if (heightStack.Count == 0 || h < heightStack.Peek())
                {
                    heightStack.Push(h);
                }
                else
                {
                    var flag = false;
                    int max = 0;
                    while (heightStack.Count > 0)
                    {
                        if (heightStack.Peek() < h)
                        {
                            subHeightStack.Push(heightStack.Pop());
                        }
                        else
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                        total += subHeightStack.Count;
                    while (subHeightStack.Count > 0)
                    {
                        heightStack.Push(subHeightStack.Pop());
                    }
                    heightStack.Push(h);
                }
            }
            return total;
        }
        /// <summary>
        /// 题解：雨水均匀落下，理论上每个下标的水面高度是无限高的，限制容量是左右柱子的高度和当前下标的柱子的高度。
        /// 1.遍历每一个下标。
        /// 2.遍历这个下标左边的柱子，找到最高的。
        /// 3.遍历这个下标右边的柱子，找到最高的。
        /// 4.水面高度由左右两个最高柱子最低那个决定，计算最低那个柱子。
        /// 5.计算当前下标的容量，水面高度减去柱子高度。
        /// 6.计算总计。
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap1(int[] height)
        {
            var total = 0;
            for (int i = 0; i < height.Length; i++)
            {
                var currentHeight = height[i];
                var leftMax = 0;
                var rightMax = 0;
                for (int l = 0; l < i; l++)
                {
                    leftMax = Math.Max(height[l], leftMax);
                }
                for (int r = i + 1; r < height.Length; r++)
                {
                    rightMax = Math.Max(height[r], rightMax);
                }
                var currentWater = Math.Min(leftMax, rightMax) - currentHeight;
                if (currentWater > 0)
                {
                    total += currentWater;
                }
            }
            return total;
        }

        /// <summary>
        /// 题解：从第一次伪代码看到。水面高度的决策条件是反复计算的，可以通过维护左向和右向的最高柱子数组，减少计算量。
        /// 1.记录从左到右最高的柱子。
        /// 2.记录从右到左最高的柱子。
        /// 3.遍历每个下标，计算容量=水面高度-柱子高度。
        /// 4.计算总和。
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap2(int[] height)
        {
            var total = 0;
            int[] leftForward = new int[height.Length];
            int[] rightForward = new int[height.Length];
            int leftMax = 0, rightMax = 0;
            for (int i = 0; i < height.Length; i++)
            {
                leftMax = Math.Max(height[i], leftMax);
                leftForward[i] = leftMax;

                rightMax = Math.Max(height[height.Length - 1 - i], rightMax);
                rightForward[height.Length - 1 - i] = rightMax;
            }
            for (int i = 0; i < height.Length; i++)
            {
                var waterHeight = Math.Min(leftForward[i], rightForward[i]);
                if (waterHeight > height[i])
                    total += waterHeight - height[i];
            }
            return total;
        }

        /// <summary>
        /// 题解：从第二次伪代码看到，左向水面高度和右向水面高度都和索引相关。左向水面高度是从最左边算起，
        /// 右向水面高度从最右边算起，在两者遇到最高点后，水面高度相等，继续遍历会消耗更多的内存和时间。
        /// 在两者下标相遇并且在最高点前，所记录的水面高度都是正确的。需要保证的是两个下标在最高点相遇。
        /// 我们仍然采取计算每个下标水面高度的思路，这一次用两个下标替代两个int数组用于记录水面高度。
        /// 1.左下标和右下标在最高点相遇是终止条件。
        /// 2.当左最高水面小于右最高水面，左下标增加，反之，右下标增加。
        /// 3.每次移动下标计算容量，更新总容量。
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap3(int[] height)
        {
            if (height.Length <= 2)
            {
                return 0;
            }
            var total = 0;
            int left = 0, right = height.Length - 1, leftMax = 0, rightMax = 0;
            while (left != right)
            {
                if (height[left] < height[right])
                {
                    leftMax = Math.Max(leftMax, height[left]);
                    total += leftMax - height[left];
                    left++;
                }
                else
                {
                    rightMax = Math.Max(rightMax, height[right]);
                    total += rightMax - height[right];
                    right--;
                }
            }
            return total;
        }
    }
}
