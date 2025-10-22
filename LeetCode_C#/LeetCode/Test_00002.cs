using System.ComponentModel.DataAnnotations;

namespace LeetCode;

public class Test_00002 {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        long num1 = ToInt(l1, 1);
        long num2 = ToInt(l2, 1);

        long result = num1 + num2;
        
        long powIndex = 10;
        
        ListNode head = null;
        ListNode prevNode = null;
        while (result > 0)
        {
            long val = result - (result / powIndex * powIndex);
            result -= val;
            val = val / (powIndex / 10);
            powIndex *= 10;

            ListNode node = new ListNode((int)val);
            if (head == null)
            {
                head = node;
                prevNode = node;
            }
            else
            {
                prevNode.next = node;
                prevNode = prevNode.next;
            }
        }
        
        return head ?? new ListNode();
    }

    public long ToInt(ListNode node, long digit){
        if(node == null)
            return 0;

        long result = ToInt(node.next, digit * 10);

        return result + (digit * node.val);
    }
}
