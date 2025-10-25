namespace LeetCode;

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */

public class Test_00206
{
    public ListNode? ReverseList(ListNode? head)
    {
        return Resolve(null, head);
    }

    private ListNode? Resolve(ListNode? prev, ListNode? current)
    {
        ListNode? result = current;
        if (current?.next != null)
        {
            result = Resolve(current, current.next);
        }

        if(current is not null)
            current.next = prev;
        return result;
    }
}

