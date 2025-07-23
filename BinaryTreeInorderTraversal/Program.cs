public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int> result = new List<int>();
        InOrderTraverse(root, result);

        return result;
    }

    private void InOrderTraverse(TreeNode root, List<int> result)
    {
        if (root == null) return;

        InOrderTraverse(root.left, result);
        result.Add(root.val);
        InOrderTraverse(root.right, result);
    }


    public static void Main(string[] args)
    {

        TreeNode root = new TreeNode(1);
        root.right = new TreeNode(2);
        root.right.left = new TreeNode(3);

        Solution sol = new Solution();
        IList<int> inorder = sol.InorderTraversal(root);

        Console.WriteLine("Inorder Traversal:");
        foreach (int val in inorder)
        {
            Console.Write(val + " ");
        }
    }

}

/*
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public IList<int> InorderTraversal(TreeNode root)
    {
        List<int> result = new List<int>();
        Stack<TreeNode> stack = new Stack<TreeNode>();
        TreeNode current = root;

        while (current != null && stack.Count > 0)
        {
            while (current.left != null)
            {
                stack.Push(current);
                current = current.left;
            }

            current = stack.Pop();
            result.Add(current.val);

            current = current.right;
        }
        return result;
    }

    public static void Main(string[] args)
    {

        TreeNode root = new TreeNode(1);
        root.right = new TreeNode(2);
        root.right.left = new TreeNode(3);

        Solution sol = new Solution();
        IList<int> inorder = sol.InorderTraversal(root);

        Console.WriteLine("Inorder Traversal:");
        foreach (int val in inorder)
        {
            Console.Write(val + " ");
        }
    }

}
*/

   