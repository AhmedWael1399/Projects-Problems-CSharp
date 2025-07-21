public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        ListNode current = head;

        while (current != null && current.next != null)
        {
            if (current.val == current.next.val)
            {
                current.next = current.next.next;
            }
            else
            {
                current = current.next;
            }
        }

        return head;
    }

    public static void PrintList(ListNode head)
    {
        while (head != null)
        {
            Console.Write(head.val + " ");
            head = head.next;
        }
        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        ListNode list = new ListNode(1,
                            new ListNode(1,
                                new ListNode(2)));

        Solution sol = new Solution();
        ListNode result = sol.DeleteDuplicates(list);

        PrintList(result);
    }
}
