namespace _0021.MergeTwoSortedLists;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(
        int val = 0, 
        ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode MergeTwoLists(
        ListNode list1,
        ListNode list2)
    {
        if (list1 == null && list2 == null)
            return null;
        
        ListNode result;
        ListNode lastNode;

        bool firstNodeFromList1 = list2 is null || (list1?.val < list2.val);
        if (firstNodeFromList1)
        {
            result = list1;
            lastNode = list1;
            list1 = list1.next;
        }
        else
        {
            result = list2;
            lastNode = list2;
            list2 = list2.next;
        }

        while (true)
        {
            bool noNextNodes = list1 is null && list2 is null;
            if (noNextNodes)
                break;

            bool fromList1 = list2 is null || (list1?.val < list2.val);
            if (fromList1)
            {
                lastNode.next = list1;
                lastNode = list1;
                list1 = list1.next;
            }
            else
            {
                lastNode.next = list2;
                lastNode = list2;
                list2 = list2.next;
            }
        }

        return result;
    }
}