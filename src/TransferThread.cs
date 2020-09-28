using System;
using System.Threading;

namespace BankSim {
    public class TransferThread {
        public static void Run(Bank bank, int fromAccount, int maxAmount){
            Random random = new Random();
            for (int i = 0; i < 10000; i++){
                int toAccount = random.Next(0, bank.NumAccounts);
                inf amount = random.Next(1, maxAmount + 1);
                bank.transfer(fromAccount, toAccount, amount);
            }
            Console.WriteLine($"Thread[{Thread.CurrentThread.ManagedThreadId}] has finished with its transactions");
        }
    }

}