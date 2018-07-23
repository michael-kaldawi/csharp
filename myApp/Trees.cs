using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace myApp
{
    public class Tree
    {
        public TreeNode root;

        public Tree()
        {
            root = new TreeNode();
        }

        public class TreeNode
        {
            public int data;
            public TreeNode left;
            public TreeNode right;

            public TreeNode() { }

            public TreeNode(int data)
            {
                this.data = data;
            }
        }

        public static Tree generateTestTree()
        {
            /*
                 Test Tree Data

                        1
                    /       \
                2               3
              /   \           /   \
            4       5       6       7

             */


            Tree tree = new Tree();
            tree.root.data = 1;
            tree.root.left = new TreeNode(2);
            tree.root.right = new TreeNode(3);
            tree.root.left.left = new TreeNode(4);
            tree.root.left.right = new TreeNode(5);
            tree.root.right.left = new TreeNode(6);
            tree.root.right.right = new TreeNode(7);

            return tree;
        }

        // BFT
        public void bft()
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                TreeNode current = q.Dequeue();
                if (current == null) continue;
                q.Enqueue(current.left);
                q.Enqueue(current.right);

                // Do Something here:
                Console.WriteLine(current.data);
            }
        }

        public void bftTest()
        {
            bft();
            // string order = bft();
            // Debug.Assert(order = "1234567")
        }
        public void inOrder(TreeNode node)
        {
            if (node == null) return;
            inOrder(node.left);
            Console.WriteLine(node.data);
            inOrder(node.right);
        }

        public void preOrder(TreeNode node)
        {
            if (node == null) return;
            Console.WriteLine(node.data);
            preOrder(node.left);
            preOrder(node.right);
        }

        public void postOrder(TreeNode node)
        {
            if (node == null) return;
            postOrder(node.left);
            postOrder(node.right);
            Console.WriteLine(node.data);
        }


        // insert implementation for min-heap
        public void insert(int data)
        {
            // assume current tree is a correct min-heap tree 


            // case 2: tree is not perfect or perfect
            // solution: 
            // 1. bft - look for first empty left or right node.
            // 2. "bubble up" the new node by comparing it with its parents. DFS postOrderTraversal

            // create a new node
            TreeNode newNode = new TreeNode(data);

            // TODO: handle empty tree case
            if (root == null) root = newNode;

            // create our queue
            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            // BFT, insertion
            while (q.Count > 0)
            {
                TreeNode current = q.Dequeue();
                if (current.left == null) current.left = newNode;
                else if (current.right == null) current.right = newNode;
                else
                {
                    q.Enqueue(current.left);
                    q.Enqueue(current.right);
                }
            }

            // DFS postOrderTraversal to "bubble up"
        }

        // TODO: complete
        public void bubbleUp(TreeNode node, TreeNode newNode)
        {
            if (node == null) return;
            bubbleUp(node.left, newNode);
            bubbleUp(node.right, newNode);
            if (node == newNode)
            {

            }
        }

        public void insertTest()
        {
            Tree tree = generateTestTree();
            tree.insert(8);

            // Assert Test tree now looks like:
            /*
                                  1
                              /       \
                          2               3
                        /   \           /   \
                      4       5       6       7
                    /
                  8
             */

            Debug.Assert(tree.root.left.left.left.data == 8);

        }

        // problem: find the first common ancestor of two nodes in a tree (the tree is not a BST)
        // solution
        /*
            1. Find the call stacks of both nodes.
            2. Compare the call stacks, and determine the common calls, and return the node at the end of the common calls.
            3.

         */

        public Stack<int> getCallStack(TreeNode current, int searchValue, Stack<int> callStack)
        {
            // how to keep callstack intact while I return?

            if(current.data == searchValue)
            {
                return callStack;
            }
            
            if(current.left != null)
            {
                callStack.Push(0);
                getCallStack(current.left, searchValue, callStack);
            } 
            
            if(current.right != null)
            {
                callStack.Push(1);
                getCallStack(current.right, searchValue, callStack);
            }

            callStack.Pop();
            return null;     
        }

        public static void postOrderTraversalTest()
        {   
            Tree testTree = generateTestTree();

            Stack<int> stack = new Stack<int>();
            stack = testTree.getCallStack(current:testTree.root, searchValue:6, callStack:stack);
            
            Debug.Assert(stack.Pop() == 0 && stack.Pop() == 1);
        }

        public TreeNode firstCommonAncestor(TreeNode A, TreeNode B)
        {
            return new TreeNode();
        }
    }

}