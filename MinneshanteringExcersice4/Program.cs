using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            // Instantiate new list
            List<string> theList = new List<string>();
            bool KeepRunning = true;
            while (KeepRunning)
            {
                Console.WriteLine("\n1. Add name");
                Console.WriteLine("2. Remove name");
                Console.WriteLine("0. Back to main menu");
                char input1 = ' ';
                //char nav = input1[0];
                //string value = input1.Substring(1);
                try
                {
                    input1 = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (input1)
                {
                    case '1':
                        AddNameToList(theList);
                        break;
                    case '2':
                        RemoveNameFromList(theList);
                        break;
                    case '0':
                        KeepRunning = false;
                        break;
                }
            }

            static void AddNameToList(List<string> theList)
            {
                Console.Write("\nAdd a name: ");
                theList.Add(Console.ReadLine()); // Adds an item to the list.
                Console.WriteLine($"The current count of your list is: {theList.Count}");
                Console.WriteLine($"The Capacity of your list is: {theList.Capacity}\n");
                PrintList(theList);
            }

            /**ÖVNING 1 - SVAR
            * 2) När minnet är fyllt av max element så ökar kapaciteten
            * 3) Kapaciteten dubbleras
            * 4) Eftersom elementen fyller upp kapaciteten, när kapaciteten är fylld så ökar den först. Elementen
            *    kommer hela tiden att traila tills kapaciteten är maximerad.
            * 5) Nej den minskar inte.
            * 6) När man vet exakt hur stor list man skall ha, då är det bättre med en egendefinierad array eftersom
            *    man då använder minsta möjlig minne.
            */
        }

        //METHOD SYNTAX EXCERSICE 1
        private static void RemoveNameFromList(List<string> theList)
        {
            Console.WriteLine("\nRemove a name!\n");
            if (theList.Count == 0)
            {
                Console.WriteLine("The list is empty, you need to add a name to the list before removing an item again!\n");
            }
            else
            {
                PrintList(theList);
                Console.WriteLine("Which name in the list do you want to remove? ");
                theList.Remove(Console.ReadLine());
                Console.WriteLine("\nNames left in the list!");
                PrintList(theList);
                Console.WriteLine($"\nThe current count of your list is: {theList.Count}");
                Console.WriteLine($"The Capacity of your list is: {theList.Capacity}\n");

            }
        }

        private static void PrintList(List<string> theList)
        {
            Console.WriteLine("The current list:");
            foreach (var name in theList)
            {

                Console.WriteLine($"  - {name}");
            }
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */

            // Create and initialize new Queue called ica
            Queue ica = new Queue();
            Console.WriteLine("\nWelcome to Ica's queue, FIFO applies here!");
            bool KeepRunning = true;
            while (KeepRunning)
            {
                Console.WriteLine("\n1. Add name to queue");
                Console.WriteLine("2. Remove from queue");
                Console.WriteLine("0. Back to main menu");
                char input2 = ' ';
                try
                {
                    input2 = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (input2)
                {
                    case '1':
                        AddCustomerToQueue(ica);
                        PrintQueue(ica);
                        break;
                    case '2':
                        RemoveCustomerFromQueue(ica);
                        PrintQueue(ica);
                        break;
                    case '0':
                        KeepRunning = false;
                        break;
                }
            }
            /**ÖVNING 3 - SVAR
            * 1) Vi vill ju inte att den färdiga kunden ska vara kvar i kön, när vi använder Stack
            *    så försvinner ju den senaste kunden som i detta exempel inte fått hjälp än!
            */
        }
        //METHOD SYNTAX EXCERSICE 2
        private static void RemoveCustomerFromQueue(Queue ica)
        {
            if (ica.Count == 0)
            {
                Console.WriteLine("The list is empty, you need to add a name to the list before removing an item again!\n");
            }
            else
            {
                Console.WriteLine("Queue order before customer leaves:");
                PrintQueue(ica);
                Console.WriteLine("\nCustomer leaving the queue: \n  - {0}", ica.Dequeue());
            }
        }

        private static void AddCustomerToQueue(Queue ica)
        {
            Console.Write("\nAdd a customer to Icas queue: ");
            ica.Enqueue(Console.ReadLine());

        }

        private static void PrintQueue(Queue ica)
        {
            Console.WriteLine("\nICA Queue:");
            foreach (var queuer in ica)
            {
                Console.WriteLine($"  - {queuer}");
            }
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            // create and initialize a new Stack called icaStack
            Stack icaStack = new Stack();
            Console.WriteLine("\nWelcome to Ica's Stack, FILO applies here!");
            bool KeepRunning = true;
            while (KeepRunning)
            {
                Console.WriteLine("\n1. Add name to queue");
                Console.WriteLine("2. Remove from queue");
                Console.WriteLine("3. Reverse Stack order ");
                Console.WriteLine("0. Back to main menu");
                char input2 = ' ';
                try
                {
                    input2 = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }

                switch (input2)
                {
                    case '1':
                        AddCustomerToQueueStack(icaStack);
                        PrintStack(icaStack);
                        break;
                    case '2':
                        RemoveCustomerFromQueueStack(icaStack);
                        PrintStack(icaStack);
                        break;
                    case '3':
                        ReverseText();
                        break;
                    case '0':
                        KeepRunning = false;
                        break;
                }
            }
        }
        //METHOD SYNTAX EXCERSICE 3
        private static void RemoveCustomerFromQueueStack(Stack icaStack)
        {
            if (icaStack.Count == 0)
            {
                Console.WriteLine("Queue is empty, add a customer!\n");
            }
            else
            {
                Console.WriteLine("\nCustomer leaving the queue: \n{0}\n", icaStack.Pop());
            }
        }
        private static void AddCustomerToQueueStack(Stack icaStack)
        {
            Console.Write("\nAdd a customer to Icas queue: ");
            icaStack.Push(Console.ReadLine());
        }
        private static void PrintStack(Stack icaStack)
        {
            Console.WriteLine("\nICA Queue:");
            foreach (var queuer in icaStack)
            {
                Console.WriteLine($"  - {queuer}");
            }
        }

        private static void ReverseText()
        {
            var stack = new Stack<char>();
            Console.Write("Type a sentence:\t");
            string sentence = Console.ReadLine();

            foreach (var c in sentence)
            {
                stack.Push(c);
            }
            sentence = string.Empty;

            while (stack.Count > 0)
            {
                sentence += stack.Pop();
            }
            Console.WriteLine($"Sentence reversed: \t{sentence}");
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            // Behöver hjälp med denna

            /**ÖVNING 4 - SVAR
           * 1) Vi använder oss av Stack eftersom vi vill åt FILO principen för att checka vilken typ
           *    av parantes som skall matchas.
           */

            Console.WriteLine("Write a sentence and include: []{}()");
            var sentence = Console.ReadLine();
            var result = BalancedString(sentence);
            if(result == true)
            {
                Console.WriteLine("The sentence is BALANCED");
            }
            else
            {
                Console.WriteLine("The sentence is NOT BALANCED");
            }
        }

        private static bool BalancedString(string sentence)
        {
            var stack = new Stack<char>();
            //string sentence = "[]}";
            
            foreach (var i in sentence)
            {
                if (i == '(' || i == '{' || i == '[')
                {
                    if (i == '(')
                    {
                        stack.Push(')');
                    }
                    else if (i == '{')
                    {
                        stack.Push('}');
                    }
                    else if (i == '[')
                    {
                        stack.Push(']');
                    }
                }
                else if (i == ')' || i == '}' || i == ']')
                {
                    if (stack.Count == 0 || stack.Pop() != i)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
/* TEORI FRÅGOR
 * 1) How does the Stack and Heap work?
 * Stack: Last -in first -out collection of objects. elements are added to the stack, one
 * on top of each other. The process of adding an element to the stack is called a push
 * operation. The top element is always removed from the stack and this is known as "pop"
 * the stack. 
 * Stack is more or less used for keeping track of whats executing in the code. Stack is faster than Heap
 * Heap: The purpose of the Heap is to hold information (not keep track of execution) so anything
 * i the heap can be accessed at any time.
 * Heap is more or less responsible for keeping track of the objects.
 * 2) What is Value Types and Reference Types, What are the differences?
 * Value types are types from System.ValueType. All "things" declared with the following list of types
 * are ValueTypes: Bool, byte, char, decimal, double, enum, float, int, long, sbyte, short, struct
 * uint, ulong, ushort.

 * Reference types are types from System.Object. All "things" declared with the types in the list are
 * reference types: Class, interface, delegate, object, string.
 * 3) Osäker på detta svar men jag tror att det är enligt nedan:
 * the first method is stored in the heap and the second is stored in the stack. The first is returning
 * 3 since there are no constraints as to what can be accessed and the second is returning 4 since it is on
 * the stack and when one "box" is executed it is discarded and the next "box" is used for memory and 4 is
 * in this "box" now (this box is now on top).
 * 
 */

