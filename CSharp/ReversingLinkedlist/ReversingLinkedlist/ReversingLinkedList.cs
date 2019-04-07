using ReversingLinkedlist;
using System;

class ReversingLinkedList {
    private static LinkedList linkedList;

    static void Main(string[] args) {
        linkedList = SetUpList();

        DoStuff(linkedList);
    }

    //Sets up the list
    private static LinkedList SetUpList() {
        LinkedList linkedList = new LinkedList();
        linkedList.AddNewNode(new Node(29));
        linkedList.AddNewNode(new Node(1));
        linkedList.AddNewNode(new Node(42));
        linkedList.AddNewNode(new Node("Middle node"));
        linkedList.AddNewNode(new Node(1337));
        linkedList.AddNewNode(new Node(80));
        linkedList.AddNewNode(new Node(404));
        return linkedList;
    }

    //Calls the print function before and after it calls the reverse function.
    private static void DoStuff(LinkedList linkedList) { 
        Console.WriteLine("Non-reversed list:");
        linkedList.Print();
 
        linkedList.ReverseAndPrint();
      
        Console.WriteLine("Reversed list:");
        linkedList.Print();
    }
}