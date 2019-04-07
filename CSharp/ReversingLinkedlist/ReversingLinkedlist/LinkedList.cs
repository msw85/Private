using System;


namespace ReversingLinkedlist {
    class LinkedList {
        private Node headNode;   
    
        //Adds note to end of list
        public void AddNewNode(Node node) {
            if (headNode == null)
                headNode = node;
            else {
                Node temp = headNode;

                while (temp.next != null) {
                    temp = temp.next;
                }

                temp.next = node;
            }
        }

        //Reverses the list
        public void Reverse() {
            Node prevNode = null;
            Node currentNode = headNode;
            Node nextNode = null;

            while (currentNode != null) {
                nextNode = currentNode.next;
                currentNode.next = prevNode;
                prevNode = currentNode;
                currentNode = nextNode;
            }

            headNode = prevNode;
        }

        //Reverses the list
        public void ReverseAndPrint() {
            Node prevNode = null;
            Node currentNode = headNode;
            Node nextNode = null;

            while (currentNode != null) {
                Console.WriteLine(" ");
                Console.WriteLine("--Redirecting one node!--");

                Console.WriteLine("Head: " + headNode);
                Console.WriteLine("Current: " + currentNode);
                Console.WriteLine("Next: " + currentNode.next);
                Console.WriteLine(" ");

                Console.WriteLine("Assigning <current.next> " + currentNode.next + " <to nextNode> " + nextNode);
                nextNode = currentNode.next;
                Console.WriteLine("Assigning <prevNode> " + prevNode + " to <currentNode.next> " + currentNode.next);
                currentNode.next = prevNode;
                Console.WriteLine("Assigning <currentNode> " + currentNode + " to <prevNode> " + prevNode);
                prevNode = currentNode;
                Console.WriteLine("Assigning <currentNode> " + currentNode + " to <prevNode> " + prevNode);
                currentNode = nextNode;

                Console.WriteLine("--Done redirecting one node!--");
                Console.WriteLine();
            }

            headNode = prevNode;
        }

        //Prints the list to Console 
        public void Print() {
            Node currentNode = headNode;

            while (currentNode != null) {
                if (currentNode.next != null) {
                    Console.Write(currentNode.data + " -> ");
                } else {
                    Console.Write(currentNode.data);
                }
                
                currentNode = currentNode.next;
            }

            Console.WriteLine();
        }
    }
}
