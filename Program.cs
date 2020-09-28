using System;

namespace BankSim
{
    class Program
    {
        public static readonly int NACCOUNTS = 10;
        public static readonly int INITIAL_BALANCE = 10000;

        static void Main(string[] args) {
            Bank bank = new Bank(NACCOUNTS, INITIAL_BALANCE);
            Thread[] threads = new Thread[NACCOUNTS];
            for (int i = 0; i < NACCOUNTS; i++){
                threads[i] = new Thread(TransferThread.Run);
                threads[i].Start(bank, i, INITIAL_BALANCE);
            }

            Console.WriteLine("Bank transfers are in progress...");
            Array.ForEach(threads, t => t.Join());
            bank.test();
        }
    }
}
