using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutionApplication
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    public class LinkedListCycle
    {
        public async Task<bool> HasCycle(ListNode head)
        {
            if (head == null || head.next == null)
                return false;

            ListNode slow = head;
            ListNode fast = head.next;

            while (slow != fast)
            {
                if (fast == null || fast.next == null)
                    return false;
                slow = slow.next;
                fast = fast.next.next;
            }
            await Task.Delay(0);
            return true;
        }

        public void InsertNode(ref ListNode head, int val)
        {
            ListNode newNode = new ListNode(val);
            if (head == null)
            {
                head = newNode;
                return;
            }

            ListNode current = head;
            while (current.next != null)
            {
                current = current.next;
            }

            current.next = newNode;
        }

        public void CreateLoop(ListNode head, int value)
        {
            ListNode loopStart = null;
            ListNode current = head;

            while (current != null)
            {
                if (current.val == value)
                {
                    loopStart = current;
                    break;
                }
                current = current.next;
            }

            if (loopStart == null)
            {
                return;
            }

            current = head;
            while (current.next != null)
            {
                current = current.next;
            }

            current.next = loopStart;
        }
    }
}
