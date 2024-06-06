using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace LeetCodeSolutionApplication
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val)
        {
            this.val = val;
        }
    }

    public class MinimumDepthOfBinaryTree
    {
        public TreeNode InsertNode(List<int> values)
        {
            if (values == null || values.Count == 0 || values[0] == -1) return null;

            TreeNode root = new TreeNode(values[0]);
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            int index = 1;

            while (queue.Count > 0 && index < values.Count)
            {
                TreeNode current = queue.Dequeue();
                if (values[index] != -1)
                {
                    current.left = new TreeNode(values[index]);
                    queue.Enqueue(current.left);
                }
                index++;
                if (index < values.Count && values[index] != -1)
                {
                    current.right = new TreeNode(values[index]);
                    queue.Enqueue(current.right);
                }
                index++;
            }

            return root;
        }

        public async Task<int> MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if (root.left == null && root.right == null) return 1;

            int leftDepth = root.left != null ? MinDepth(root.left).Result : int.MaxValue;
            int rightDepth = root.right != null ? MinDepth(root.right).Result : int.MaxValue;

            await Task.Delay(0);
            return Math.Min(leftDepth, rightDepth) + 1;
        }
    }
}
