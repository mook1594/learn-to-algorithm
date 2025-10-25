namespace LeetCode;

public class LinkedList 
{
    public static ListNode? FromIntArray(int[] inputs)
    {
        ListNode? node = null;
        ListNode? headNode = null;
        ListNode? prevNode = null;
        for (int i = 0; i < inputs.Length; i++)
        {
            node = new ListNode()
            {
                val = inputs[i],
                next = null
            };
            if (prevNode != null)
                prevNode.next = node;
            else
                headNode = node;

            prevNode = node;
        }
        return headNode;
    }

    public static int[] ToIntArray(ListNode? head)
    {
        List<int> listResult = new List<int>();

        while (head != null)
        {
            listResult.Add(head.val);
            head = head.next;
        }
        return listResult.ToArray();
    }
}

