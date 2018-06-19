using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;


namespace myApp
{


    // Singly linked list interface
    interface LinkedList
    {
        void appendToTail(Node node);
        Node deleteNode(Node node);
        // void append(Object content);
    }

    // Node Object
    public class Node
    {
        public Node next;
        public int content;

        public Node(int content)
        {
            this.content = content;
        }
    }

    public class SinglyLinkedList : LinkedList
    {
        public Node head;

        public SinglyLinkedList()
        {
        }
        public SinglyLinkedList(Node node)
        {
            this.head = node;
        }

        public void appendToTail(Node node)
        {
            Node n = this.head;
            while (n.next != null)
            {
                n = n.next;
            }
            n.next = node;
        }

        public Node deleteNode(Node node)
        {
            Node n = this.head;
            if (n.content == node.content)
            {
                this.head = this.head.next;
                return this.head;
            }

            while (n.next != null)
            {
                if (n.next.content == node.content)
                {
                    n.next = n.next.next;
                    return this.head;
                }
                n = n.next;
            }
            return this.head;
        }

        public void appendToTailTest()
        {
            SinglyLinkedList list = new SinglyLinkedList(new Node(10));

            list.appendToTail(new Node(20));

            Debug.Assert(list.head.content == 10);
            Debug.Assert(list.head.next.content == 20);
            Debug.Assert(list.head.next.next == null);

            list.deleteNode(new Node(10));
        }

        public void deleteNodeTest()
        {
            SinglyLinkedList list = new SinglyLinkedList(new Node(10));

            list.appendToTail(new Node(20));

            list.deleteNode(new Node(10));

            Debug.Assert(list.head.content == 20);
            Debug.Assert(list.head.next == null);
        }

        public void removeDuplicates(){
            Node head = this.head;
            HashSet<int> hset = new HashSet<int>(head.content);

            Node prev = null;

            while(head != null){
                if(hset.Contains(head.content)){
                    prev.next = prev.next.next;
                }
                else{
                    hset.Add(head.content);
                }
                prev = head;
                head = head.next;
            }
        }

        public void removeDuplicatesTest(){
            SinglyLinkedList list = new SinglyLinkedList(new Node(10));
            list.appendToTail(new Node(20));
            list.appendToTail(new Node(30));
            list.appendToTail(new Node(20));

            list.removeDuplicates();

            Debug.Assert(list.head.content == 10);
            Debug.Assert(list.head.next.content == 20);
            Debug.Assert(list.head.next.next.content == 30);
            Debug.Assert(list.head.next.next.next == null);
        }

        public Node kthFromTail(Node head, int k){
            
            // move a pointer to the kth node;
            Node copy = head;
            for(int i=0; i < k; i++){
                copy = copy.next;
            }

            // move two pointers simultaneously, until reach the tail. 
            // Head will now be k nodes from the tail.
            while(copy.next != null){
                copy = copy.next;
                head = head.next;
            }

            return head;
        }

        public void kthFromTailTest(){
            SinglyLinkedList list = new SinglyLinkedList(new Node(10));
            list.appendToTail(new Node(20));
            list.appendToTail(new Node(30));
            list.appendToTail(new Node(40));

            int kthFromTailValue = kthFromTail(list.head, 2).content;
            Debug.Assert(kthFromTailValue == 20);
        }
    }
}