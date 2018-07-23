using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace myApp
{
    public class SetOfStacks
    {
        static int maxStackSize = 3;
        StackNode top  = new StackNode();

        private class StackNode
        {
            public Stack<string> stack = new Stack<string>();
            public StackNode next;

        }

        public void push(string data)
        {
            if (top.stack.Count >= 3)
            {
                StackNode newTop = new StackNode();
                newTop.next = top;
                top = newTop;
                top.stack.Push(data);
            }
            else top.stack.Push(data);
        }

        public string pop()
        {
            if (top.stack == null) throw new InvalidOperationException(message: "Stacks are empty");
            else
            {
                string returnValue = top.stack.Pop();
                if (top.stack.Count == 0 && top.next != null)
                {
                    top = top.next;
                }

                return returnValue;
            }
        }

        public string popAt(int n)
        {
            StackNode temp = top;
            for(int i=1; i < n; i++)
            {
                if(temp.next != null) temp = temp.next;
                else throw new InvalidOperationException(message:$"Stack {n} does not exist.");
            }

            return temp.stack.Pop();

        }

        public void popAtTest()
        {
            push("failure");
            push("failure");
            push("failure");

            push("failure");
            push("failure");
            push("success");

            push("failure");
            push("failure");
            push("failure");

            push("failure");
            push("failure");

            Debug.Assert(popAt(3) == "success");
        }
    }
}