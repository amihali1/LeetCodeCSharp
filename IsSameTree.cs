//  https://leetcode.com/problems/same-tree/
// Given the roots of two binary trees p and q, write a function to check if they are the same or not.
// Two binary trees are considered the same if they are structurally identical, and the nodes have the same value.

// Definition for a binary tree node.
public class TreeNode {
  public int val;
  public TreeNode left;
  public TreeNode right;
  public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
      this.val = val;
      this.left = left;
      this.right = right;
  }
}

public class Solution 
{
    public bool IsSameTree(TreeNode p, TreeNode q) 
    {
        var q1 = new Queue<TreeNode>();
        var q2 = new Queue<TreeNode>();
        q1.Enqueue(p);
        q2.Enqueue(q);

        if ((p == null && q != null) ||
            (p != null && q == null))
            return false;
        
        while (q1.Any())
        {
            var q1Node = q1.Dequeue();
            var q2Node = q2.Dequeue();

            if (q1Node?.val != q2Node?.val)
                return false;

            if (q1Node != null)
            {
                q1.Enqueue(q1Node.left);
                q1.Enqueue(q1Node.right);
            }

            if (q2Node != null)
            {
                q2.Enqueue(q2Node.left);
                q2.Enqueue(q2Node.right);
            }
        }
        return true;
    }
}
