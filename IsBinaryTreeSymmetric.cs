// https://leetcode.com/problems/symmetric-tree/
// Given the root of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
// Definition for a binary tree node.

using System.Runtime.InteropServices;

var tree = BuildTree(new int?[] {2,3,3,4,5,5,4,null,null,8,9,9,8});
var tree0 = BuildTree(new int?[] {2,3,3,4,5,5,4,6,null,8,9,9,8,null,6});

Console.WriteLine(new Solution().IsSymmetric(tree));
Console.WriteLine(new Solution().IsSymmetric(tree0));

TreeNode BuildTree(int?[] tree)
{
    var rootNode = new TreeNode(tree[0].Value);
    var currentNodes = (new[] { rootNode }).AsEnumerable();

    int levels = 1;
    int level = 1;
    int index = 1;
    
    while (true)
    {
        if (tree.Length > Math.Pow(levels, 2))
            levels++;
        else
            break;
    }

    while (level < levels)
    {
        currentNodes = AddNodes(currentNodes, tree, ref index);
        
        if (index >= Math.Pow(2, level))
            level++;
    }

    return rootNode;
}

IEnumerable<TreeNode> AddNodes(IEnumerable<TreeNode> previousLevel, int?[] tree, ref int index)
{
    var newLevel = new List<TreeNode>();
    foreach (var node in previousLevel)
    {
        if (index < tree.Length)
        {
            node.left = tree[index].HasValue ? new TreeNode(tree[index].Value) : null;
            newLevel.Add(node.left);
        }

        if (index + 1 < tree.Length)
        {
            node.right = tree[index + 1].HasValue ? new TreeNode(tree[index+1].Value) : null;
            newLevel.Add(node.right);
        }
        index += 2;
    }

    return newLevel;
}

public class TreeNode {
  public int val;
  public TreeNode left;
  public TreeNode right;
  public TreeNode parent;
  public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
      this.val = val;
      this.left = left;
      this.right = right;
  }
}

public class Solution 
{
    public bool IsSymmetric(TreeNode root)
    {
        var leftTree = new Queue<TreeNode>();
        var rightTree = new Queue<TreeNode>();
        
        if (root?.left?.val != root?.right?.val)
            return false;

        leftTree.Enqueue(root.left);
        rightTree.Enqueue(root.right);

        while (leftTree.Any())
        {
            var leftTreeNode = leftTree.Dequeue();
            var rightTreeNode = rightTree.Dequeue();
 
            if (leftTreeNode?.left?.val != rightTreeNode?.right?.val ||
                leftTreeNode?.right?.val != rightTreeNode?.left?.val)
                return false;
            
            if (leftTreeNode != null)
            {
                leftTree.Enqueue(leftTreeNode.left);
                leftTree.Enqueue(leftTreeNode.right);
            }
            if (rightTreeNode != null)
            {
                rightTree.Enqueue(rightTreeNode.right);
                rightTree.Enqueue(rightTreeNode.left);
            }
        }
        return true;
    }
}
