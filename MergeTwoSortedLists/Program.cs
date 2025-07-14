public class Solution
{
    public class ListNode
    {
        public int value;
        public ListNode? next;

        public ListNode(int value = 0, ListNode? next = null)
        {
            this.value = value;
            this.next = next;
        }
    }

    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ListNode dummy = new ListNode(-1);
        ListNode current = dummy;

        while (list1 != null && list2 != null)
        {
            if (list1.value <= list2.value)
            {
                current.next = list1;
                list1 = list1.next!;
            }
            else
            {
                current.next = list2;
                list2 = list2.next!;
            }
            current = current.next;
        }
        current.next = list1 ?? list2;

        return dummy.next!;
    }

    public static void Main(string[] args)
    {
        ListNode a = new Solution.ListNode(1, new Solution.ListNode(3, new Solution.ListNode(5)));
        ListNode b = new Solution.ListNode(2, new Solution.ListNode(4, new Solution.ListNode(6)));
        ListNode result = new Solution().MergeTwoLists(a, b);

        while (result != null)
        {
            Console.Write(result.value + " ");
            result = result.next!;
        }
    }
}

