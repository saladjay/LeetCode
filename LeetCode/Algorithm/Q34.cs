using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Q34
    {
        /*
            给定一个按照升序排列的整数数组 nums，和一个目标值 target。找出给定目标值在数组中的开始位置和结束位置。

            如果数组中不存在目标值 target，返回 [-1, -1]。

            进阶：

            你可以设计并实现时间复杂度为 O(log n) 的算法解决此问题吗？
 

            示例 1：

            输入：nums = [5,7,7,8,8,10], target = 8
            输出：[3,4]
            示例 2：

            输入：nums = [5,7,7,8,8,10], target = 6
            输出：[-1,-1]
            示例 3：

            输入：nums = [], target = 0
            输出：[-1,-1]
 

            提示：

            0 <= nums.length <= 105
            -109 <= nums[i] <= 109
            nums 是一个非递减数组
            -109 <= target <= 109

            来源：力扣（LeetCode）
            链接：https://leetcode-cn.com/problems/find-first-and-last-position-of-element-in-sorted-array
            著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */

        /// <summary>
        /// 这题目应该嵌套使用二分法寻找Target。根据题意，我们得知我们需要寻找到第一个Target的位置和最后一个Target的位置，而常规的二分法是寻找一个符合条件的数字。在我们第一次找到符合条件的数字后，
        /// 我们得知所给的数组里有target,如果第一次二分法都没找到target，那么可以直接返回[-1,-1]。得知有符合条件的数字后，我们开始用第二次二分法，找到Target的头和尾。
        /// </summary>
        public int[] SearchRange(int[] nums, int target)
        {
            var mid = nums.Length / 2;
            var end = nums.Length - 1;
            var start = 0;
            var res = new List<int>();
            while (start <= end)
            {
                mid = (start + end) / 2;
                if (nums[mid] < target)
                {
                    start = mid + 1;//mid小于target，可以进行移动一位。
                }
                if (nums[mid] > target)
                {
                    end = mid - 1;//mid小于target，可以进行移动一位。
                }
                if (nums[mid] == target)//开始第二次和第三次的二分法，去寻找target的头和尾。
                {
                    var subStart = start;
                    var subEnd = mid;
                    var subMid = 0;
                    while (nums[subStart]!=target)
                    {
                        subMid = (subStart + subEnd) / 2;
                        if (nums[subMid] < target)
                        {
                            subStart = subMid + 1;
                        }
                        if (nums[subMid] == target)
                        {
                            subEnd = subMid - 1;
                        }
                    }
                    start = subStart;
                    subStart = mid;
                    subEnd = end;
                    subMid = 0;
                    while (nums[subEnd]!=target)
                    {
                        subMid = (subStart + subEnd) / 2;
                        if (nums[subMid] == target)
                        {
                            subStart = subMid + 1;
                        }
                        if (nums[subMid] > target)
                        {
                            subEnd = subMid - 1;
                        }
                    }
                    end = subEnd;
                    return new int[] { start, end };

                }

            }
            return new int[] { -1, -1 };
        }

        public int[] BestAnswear(int[] nums,int target)
        {
            return new int[] { Array.IndexOf(nums, target), Array.LastIndexOf(nums, target) };
        }
    }
}
