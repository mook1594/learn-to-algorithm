using System.ComponentModel.DataAnnotations;

namespace LeetCode;

public class Test_00002 {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode c1 = l1;
        ListNode c2 = l2;

        ListNode resultNode = null;
        ListNode currentResult = null;
        int carry = 0;
        while(c1 != null || c2 != null){
            int n1 = c1?.val ?? 0;
            int n2 = c2?.val ?? 0;
            int val = n1 + n2 + carry;

            carry = 0;
            if(val >= 10){
                carry = 1;
                val -= 10;
            }
            if (resultNode == null)
            {
                resultNode = new(val);
                currentResult = resultNode;
            }
            else
            {
                currentResult.next = new(val);
                currentResult = currentResult.next;
            }

            c1 = c1?.next;
            c2 = c2?.next;
        }
        if(carry == 1){
            currentResult.next = new (carry);
        }

        return resultNode ?? new ListNode();
    }
}
