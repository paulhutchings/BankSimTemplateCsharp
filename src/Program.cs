using System;
using System.Threading;
using BankSim;

namespace Program
{
    class Program
    {
        public static readonly int NACCOUNTS = 10;
        public static readonly int INITIAL_BALANCE = 10000;

        static void Main(string[] args) {
            Bank bank = new Bank(NACCOUNTS, INITIAL_BALANCE);
            Thread[] threads = new Thread[NACCOUNTS];
            for (int i = 0; i < NACCOUNTS; i++){
                threads[i] = new Thread(TransferThreadRun);
                threads[i].Start(new Object[] {bank, i, INITIAL_BALANCE});
            }

            Console.WriteLine("Bank transfers are in progress...");
            Array.ForEach(threads, t => t.Join());
            bank.test();
        }

        public static void TransferThreadRun(Object argsArr){
            Object[] args = (Object[]) argsArr;
            Bank bank = (Bank)args[0];
            int fromAccount = (int) args[1];
            int maxAmount = (int) args[2];

            Random random = new Random();
            for (int i = 0; i < 10000; i++){
                int toAccount = random.Next(0, bank.NumAccounts);
                int amount = random.Next(1, maxAmount + 1);
                bank.transfer(fromAccount, toAccount, amount);
            }
            Console.WriteLine($"Thread[{Thread.CurrentThread.ManagedThreadId}] has finished with its transactions");
        }
    }
}
