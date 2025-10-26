
using System.Text.RegularExpressions;

namespace LeetCode;

public class Test_00025
{
    public ListNode ReverseKGroup(ListNode node, int k)
    {
        int index = 0;
        ListNode curNode = node;
        while (curNode != null && index < k)
        {
            curNode = curNode.next;
            index++;
        }

        if (k == index)
        {
            ListNode hNode = ReverseKGroup(curNode, k);

            for (int i = 1; i <= k; i++)
            {
                ListNode tempNode = node.next;
                node.next = hNode;
                hNode = node;
                node = tempNode;
            }
            node = hNode;
        }

        return node;
    }
}