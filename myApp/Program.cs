using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace myApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ArraysAndStrings aas = new ArraysAndStrings();
            // 1.1
            aas.uniqueCharsTest();
            // 1.2
            aas.isPermutationTest();
            // 1.3
            aas.URLifyTest();
            // 1.4
            aas.isPalPermTest();

            SinglyLinkedList list = new SinglyLinkedList();
            // 2.1
            list.removeDuplicatesTest();
            // 2.2
            list.kthFromTailTest();
            // 2.3
            
        }
    }
}
