using System;
using System.Collections.Generic;

namespace TestConsoleApp
{
    delegate int NumberChange(int num);
    class Program
    {
        public static int StackLine { get; set; } = 4;
        static int num = 10;
        public static int Add(int p) { return num += p; }
        public static int Multiply(int q) { return num *= q; }
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(StackLine);
            Console.WriteLine($"1:{stack.Pop()} 2:{stack.Peek()} 3:{stack.Pop()}");
            Client client = new Client() { Name = "Mohammed" };
            Nullable<Decimal> balance = client?.account?.Balance;
            Console.WriteLine($"Naw Client created : {client.Name} with balance : {balance}");
            NumberChange ncAggregation;
            NumberChange ncAdd = new NumberChange(Add);
            NumberChange ncMulti = new NumberChange(Multiply);
            ncAggregation = ncAdd;
            ncAggregation += ncMulti;
            Console.WriteLine($"Value Of : {ncAggregation(5)}");
        }
    }

    public class Client
    {
        public string Name { get; set; }
        public AccountBank account { get; set; }
    }

    public class AccountBank
    {
        public Decimal Balance { get; set; } = 99.9m;
    }
}
