using System;

namespace HWQueue
{
    class Program
    {

        static void Main(string[] args)
        {

            Queue CPUQueue = new Queue();
            char instruction, data;
            int count = 0;
            while (true)
            {
                instruction = char.Parse(Console.ReadLine());
                Node instQueue;
                instQueue = CPUQueue.Pop();
                count++;
                if (instQueue == null)
                {
                    break;
                }
                data = char.Parse(Console.ReadLine());
                Instruction CPU = new Instruction(instruction);
                CPUQueue.Push(CPU);

            }
            Console.WriteLine("CPU cycles needed:" + count);
        }
    }
    class Instruction
    {
        public char instruction;
        public Instruction Next;
        public Instruction(char instructionValue)
        {
            instruction = instructionValue;
        }
        public override string ToString()
        {
            return String.Format("({0}", instruction);
        }

    }
    class Data
    {
        public char data;
        public Data (char dataValue)
        {
            data = dataValue;
        }
        public override string ToString()
        {
            return String.Format("({0})", data);
        }
    }
    class Node
    {
        public char Instruction;
        public char Data;
        public Node Next;
        public Node(char instructionValue, char dataValue)
        {
            Instruction = instructionValue;
            Data = dataValue;
        }
        public override string ToString()
        {
            return String.Format("({0}, {1})", Instruction, Data);
        }

    }
    class Queue
    {
        private Node Root;
        public void Push(Node node)
        {
            if (Root == null)
            {
                Root = node;
            }
            else
            {
                Node ptr = Root;
                while (ptr.Next != null)
                {
                    ptr = ptr.Next;
                }
                ptr.Next = node;
            }
        }
        public Node Pop()
        {
            if (Root == null)
            {
                return null;
            }
            Node node = Root;
            Root = Root.Next;
            node.Next = null;
            return node;
        }
        public Node Get(int index)
        {
            Node node = Root;
            while (index > 0)
            {
                if (node == null)
                {
                    throw new IndexOutOfRangeException();
                }
                node = node.Next;
                index--;
            }
            return node;
        }

    }
}