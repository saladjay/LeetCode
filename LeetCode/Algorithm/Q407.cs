using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCare.Emr.IWcf;
namespace LeetCode.Algorithm
{
    public class Q407 : IExecuteTest
    {
        public bool Test()
        {
            var res1 = TrapRainWater(new int[][]
            {
                new int[]{1,4,3,1,3,2},
                new int[]{3,2,1,3,2,4},
                new int[]{2,3,3,2,3,1},
            }) == 4;
            var res2 = TrapRainWater(new int[][]
            {
                new int[]{12,13,1,12},
                new int[]{13,4,13,12},
                new int[]{13,8,10,12},
                new int[]{12,13,12,12},
                new int[]{13,13,13,13}
            }) == 14;
            return res1 & res2;
        }
        /*
         给你一个 m x n 的矩阵，其中的值均为非负整数，代表二维高度图每个单元的高度，请计算图中形状最多能接多少体积的雨水。

 

        示例：

        给出如下 3x6 的高度图:
        [
          [1,4,3,1,3,2],
          [3,2,1,3,2,4],
          [2,3,3,2,3,1]
        ]

        返回 4 。

        如上图所示，这是下雨前的高度图[[1,4,3,1,3,2],[3,2,1,3,2,4],[2,3,3,2,3,1]] 的状态。

 
        下雨后，雨水将会被存储在这些方块中。总的接雨水量是4。

 

        提示：

        1 <= m, n <= 110
        0 <= heightMap[i][j] <= 20000

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/trapping-rain-water-ii
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */
        /// <summary>
        /// 参考问题42。水面高度由多路径决定，不再是左右或者上下。
        /// </summary>
        /// <param name="heightMap"></param>
        /// <returns></returns>
        public int TrapRainWater(int[][] heightMap)
        {
            int[][] waterHeight = new int[heightMap.Length][];

            for (int i = 0; i < heightMap.Length; i++)
            {
                var row = heightMap[i];
                waterHeight[i] = SingleDimensonHeight(row);
            }

            for ( int j = 0; j < heightMap[0].Length; j++)
            {
                var column = new int[heightMap.Length];
                for (int i = 0; i < heightMap.Length; i++)
                {
                    column[i] = heightMap[i][j];
                }
                column = SingleDimensonHeight(column);
                for (int i = 0; i < heightMap.Length; i++)
                {
                    waterHeight[i][j] = Math.Min(waterHeight[i][j], column[i]);
                }
            }
            var total = 0;
            for (int i = 0; i < heightMap.Length; i++)
            {
                for (int j = 0; j < heightMap[0].Length; j++)
                {
                    total += waterHeight[i][j] - heightMap[i][j];
                }
            }
            return total;
        }
        public int[] SingleDimensonHeight(int[] heights)
        {
            int left = 0, right = heights.Length - 1, leftMax = 0, rightMax = 0;
            int[] horizontalHeight = new int[heights.Length];
            while (left < right)
            {
                if (heights[left] < heights[right])
                {
                    leftMax = Math.Max(heights[left], leftMax);
                    horizontalHeight[left] = leftMax;
                    left++;
                }
                else
                {
                    rightMax = Math.Max(heights[right], rightMax);
                    horizontalHeight[right] = rightMax;
                    right--;
                }
            }
            horizontalHeight[left] = heights[left];
            return horizontalHeight;
        }
    }
}
