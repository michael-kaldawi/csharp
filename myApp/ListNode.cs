using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myApp
{    
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) {val = x; }

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            // Get the values of the two ListNodes
            int multiplier = 1;
            int l1Value = 0;
            
            ListNode tempNode = l1;
            while(tempNode != null) 
            {
                l1Value += multiplier*l1.val;
                multiplier *= 10;                
                tempNode = l1.next;
            }     
            
            multiplier = 1;
            int l2Value = 0;
            
            tempNode = l2;
            while(tempNode != null) 
            {
                l2Value += multiplier*l2.val;
                multiplier *= 10;                
                tempNode = l2.next;
            }     

            // Add the values
            int sum = l1Value + l2Value;

            // Insert the sum into a new ListNode
            string sumStr = sum.ToString();
            


            // ListNode tempList = sumList;
            // for(int i=0; i<sumStr.Length; i++){
            //     sumList = new ListNode(sumStr[i]);

            // }
            return l1;
        }
    }
}