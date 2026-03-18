using System;

namespace DSA
{
   
    class Node
    {
        public int empId;
        public string empName;
        public Node next;

        public Node(int id, string name)
        {
            empId = id;
            empName = name;
            next = null;
        }
    }

    class LinkedList
    {
        Node head;

      
        public void InsertAtBeginning(int id, string name)
        {
            Node newNode = new Node(id, name);
            newNode.next = head;
            head = newNode;
        }

        public void InsertAtEnd(int id, string name)
        {
            Node newNode = new Node(id, name);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }

            temp.next = newNode;
        }

        public void Delete(int id)
        {
            if (head == null)
                return;

            if (head.empId == id)
            {
                head = head.next;
                return;
            }

            Node temp = head;
            while (temp.next != null && temp.next.empId != id)
            {
                temp = temp.next;
            }

            if (temp.next != null)
            {
                temp.next = temp.next.next;
            }
        }

     
        public void Display()
        {
            Node temp = head;

            while (temp != null)
            {
                Console.WriteLine(temp.empId + " - " + temp.empName);
                temp = temp.next;
            }
        }
    }

    internal class Employee_Management_Using_Linked_List
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

   
            list.InsertAtEnd(101, "Seno");
            list.InsertAtEnd(102, "Tara");
            list.InsertAtEnd(103, "Sonu");

         
            list.Delete(102);

            Console.WriteLine("Employee List After Deletion:");
            list.Display();
        }
    }
}