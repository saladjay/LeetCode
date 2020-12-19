using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Q48 : IExecuteTest
    {
        public bool Test()
        {
            var matrix1 = new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5,6},
                new int[]{7,8,9}
            };
            Rotate(matrix1);
            var answear1 = new int[][]
            {
                new int[]{7,4,1},
                new int[]{8,5,2},
                new int[]{9,6,3}
            };
            var res1 = TestMatrix(matrix1, answear1);

            var matrix2 = new int[][]
            {
                new int[]{ 5, 1, 9,11},
                new int[]{ 2, 4, 8,10},
                new int[]{ 13, 3, 6, 7 },
                new int[]{ 15, 14, 12, 16 }
            };
            Rotate(matrix2);
            var answear2 = new int[][]
            {
                new int[]{ 15, 13, 2, 5 },
                new int[]{ 14, 3, 4, 1 },
                new int[]{ 12, 6, 8, 9 },
                new int[]{ 16, 7, 10, 11 },
            };
            var res2 = TestMatrix(matrix2, answear2);
            return res1 & res2;
        }

        public bool TestMatrix(int[][] matrix1, int[][] matrix2)
        {
            if (matrix1.GetLength(0) != matrix2.GetLength(0))
            {
                return false;
            }
            if (matrix1[0].GetLength(0) != matrix2[0].GetLength(0))
            {
                return false;
            }
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                var row1 = matrix1[0];
                var row2 = matrix2[0];
                if (row1 == null || row2 == null)
                {
                    return false;
                }
                for (int j = 0; j < matrix1[0].GetLength(0); j++)
                {
                    if (row1[j] != row2[j])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /*
         给定一个 n × n 的二维矩阵表示一个图像。

        将图像顺时针旋转 90 度。

        说明：

        你必须在原地旋转图像，这意味着你需要直接修改输入的二维矩阵。请不要使用另一个矩阵来旋转图像。

        示例 1:

        给定 matrix = 
        [
          [1,2,3],
          [4,5,6],
          [7,8,9]
        ],

        原地旋转输入矩阵，使其变为:
        [
          [7,4,1],
          [8,5,2],
          [9,6,3]
        ]
        示例 2:

        给定 matrix =
        [
          [ 5, 1, 9,11],
          [ 2, 4, 8,10],
          [13, 3, 6, 7],
          [15,14,12,16]
        ], 

        原地旋转输入矩阵，使其变为:
        [
          [15,13, 2, 5],
          [14, 3, 4, 1],
          [12, 6, 8, 9],
          [16, 7,10,11]
        ]

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/rotate-image
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */
        public void Rotate(int[][] matrix)
        {
            var n = matrix.GetLength(0);
            var loop = n / 2;
            var tempNum1 = 0;
            var tempNum2 = 0;
            var tempNum3 = 0;
            var tempNum4 = 0;
            for (int i = 0; i < loop; i++)
            {
                var count = n - 2 * i;
                if (count <= 1)
                {
                    break;
                }
                for (int j = 0; j < count - 1; j++)
                {
                    tempNum1 = matrix[0 + i][0 + i + j];
                    tempNum2 = matrix[0 + i + j][n - i - 1];
                    tempNum3 = matrix[n - 1 - i][n - 1 - j - i];
                    tempNum4 = matrix[n - 1 - i - j][0 + i];

                    matrix[0 + i][0 + i + j] = tempNum4;
                    matrix[0 + i + j][n - i - 1] = tempNum1;
                    matrix[n - 1 - i][n - 1 - j - i] = tempNum2;
                    matrix[n - 1 - i - j][0 + i] = tempNum3;
                }
            }
        }

        public void RotateRing(int[][] matrix, int first, int last)
        {
            for (int i = 0; i < last - first; i++)
            {
                (matrix[first][first + i], matrix[first + i][last], matrix[last][last-i], matrix[last-i][first]) =
                    (matrix[last - i][first], matrix[first][first + i], matrix[first + i][last], matrix[last][last - i]);
            }
        }

        public void SubRotate(int[][] matrix, int first, int last)
        {
            if (first >= last)
            {
                return;
            }
            RotatoRing(matrix, first, last);
            SubRotato(matrix, first + 1, last - 1);
        }

        public void RotateBest(int[][] matrix)
        {
            SubRotato(matrix, 0, matrix.GetLength(0) - 1);
        }
    }
}
