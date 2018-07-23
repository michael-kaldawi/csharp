using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace myApp
{    
    public class MyStack
    {
        private class StackNode
        {
            public StackNode next;
            public int data;

            public StackNode(int data)
            {
                this.data = data;
            }
        }
        
        StackNode top;
        int min;

        public MyStack()
        {
            min = Int32.MaxValue;
        }

        public void push(int data)
        {
            StackNode newNode = new StackNode(data);
            newNode.next = this.top;
            this.top = newNode;
            if(data < min) min = data;
        }

        public int pop()
        {
            if(top == null) throw new InvalidOperationException(message:"The stack is empty");
            int returnValue = this.top.data;
            this.top = this.top.next;
            return returnValue;
        }

        public int peek()
        {
            return top.data;
        }

        public int popNsum(int n)
        {
            int sum = 0;
            while(n > 0)
            {
                n--;
                sum+=pop();
            }
            return sum;
        }

        public void popNsumTest()
        {
            // push some values onto the stack;
            push(1);
            push(2);
            push(3);
            push(4);
            push(5);

            int sum = popNsum(5);
            Debug.Assert(sum == 15);
        }

        public int findMin()
        {
            int min = peek();
            MyStack tempStack = new MyStack();

            // pop everything off the stack into another stack
            while(top != null)
            {
                if(peek() < min) min = peek();
                tempStack.push(pop());
            }
            // return the items to the stack
            while(tempStack.top != null)
            {
                this.push(tempStack.pop());
            }

            return min;
        }

        public void minTest()
        {
            this.push(1);
            this.push(-4);
            this.push(9);

            Debug.Assert(findMin() == -4);
            Debug.Assert(min == -4);
            Debug.Assert(pop() == 9 && pop() == -4 && pop() == 1);
        }
    }    
}