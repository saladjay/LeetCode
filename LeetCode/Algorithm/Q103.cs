using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithm
{
    public class Q103 : IExecuteTest
    {
        public bool Test()
        {
            throw new Exception();
        }

        /*
         给定一个二叉树，返回其节点值的锯齿形层序遍历。（即先从左往右，再从右往左进行下一层遍历，以此类推，层与层之间交替进行）。

        例如：
        给定二叉树 [3,9,20,null,null,15,7],

            3
           / \
          9  20
            /  \
           15   7
        返回锯齿形层序遍历如下：

        [
          [3],
          [20,9],
          [15,7]
        ]

        来源：力扣（LeetCode）
        链接：https://leetcode-cn.com/problems/binary-tree-zigzag-level-order-traversal
        著作权归领扣网络所有。商业转载请联系官方授权，非商业转载请注明出处。
         */

        //
        //Definition for a binary tree node.
        public class TreeNode
        {
            public int val;
            public TreeNode left;
            public TreeNode right;
            public TreeNode(int x) { val = x; }
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            Stack<TreeNode> leftNodes = new Stack<TreeNode>();
            Stack<TreeNode> rightNodes = new Stack<TreeNode>();

            IList<IList<int>> answear = new List<IList<int>>();
            leftNodes.Push(root);
            GenerateZigzagLevel(leftNodes, rightNodes, answear);
            return answear;
        }

        public void GenerateZigzagLevel(Stack<TreeNode> leftNodes, Stack<TreeNode> rightNodes, IList<IList<int>> answear)
        {
            if (leftNodes.Count == 0 && rightNodes.Count == 0)
            {
                return;
            }
            if (leftNodes.Count > 0)
            {
                List<int> leftList = new List<int>();
                while (leftNodes.Count > 0)
                {
                    var node = leftNodes.Pop();
                    if (node == null)
                    {
                        continue;
                    }
                    leftList.Add(node.val);
                    if (node.left != null)
                        rightNodes.Push(node.left);
                    if (node.right != null)
                        rightNodes.Push(node.right);
                }
                if (leftList.Count > 0)
                    answear.Add(leftList);
                GenerateZigzagLevel(leftNodes, rightNodes, answear);
            }
            if (rightNodes.Count > 0)
            {
                List<int> rightList = new List<int>();
                while (rightNodes.Count > 0)
                {
                    var node = rightNodes.Pop();
                    if (node == null)
                    {
                        continue;
                    }
                    rightList.Add(node.val);
                    if (node.right != null)
                        leftNodes.Push(node.right);
                    if (node.left != null)
                        leftNodes.Push(node.left);
                }
                if (rightList.Count > 0)
                    answear.Add(rightList);
                GenerateZigzagLevel(leftNodes, rightNodes, answear);
            }
        }
    }
}
