using System;

namespace DSA
{
    internal class Stack_Based_Undo_System
    {
        static string[] stack = new string[10];
        static int top = -1; 

        
        static void Push(string action)
        {
            if (top == stack.Length - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }

            top++;
            stack[top] = action;
            DisplayState();
        }

        
        static void Pop()
        {
            if (top == -1)
            {
                Console.WriteLine("Nothing to undo (Stack Empty)");
                return;
            }

            Console.WriteLine("Undo: " + stack[top]);
            top--;
            DisplayState();
        }

    
        static void DisplayState()
        {
            Console.Write("Current Actions: ");

            if (top == -1)
            {
                Console.WriteLine("No actions");
                return;
            }

            for (int i = 0; i <= top; i++)
            {
                Console.Write(stack[i] + " ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
         
            Push("Type A");
            Push("Type B");
            Push("Type C");

            Pop(); 
            Pop(); 

            Console.WriteLine("\nFinal State:");
            DisplayState();
        }
    }
}