using System;
using System.Linq;

namespace BankSim {
    public class Bank {
        public static readonly int NTEST = 10;
        private readonly Account[] accounts;
        private long numTransactions;

        private readonly int initialBalance;
        public int NumAccounts { get; }

        public Bank(int numAccounts, int initialBalance){
            this.initialBalance = initialBalance;
            this.NumAccounts = numAccounts;
            this.numTransactions = 0;
            this.accounts = new Account[numAccounts];
            for (int i = 0; i < this.NumAccounts; i++){
                this.accounts[i] = new Account(i, this.initialBalance);
            }
        }

        public void transfer(int from, int to, int amount){
            if (this.accounts[from].withdrawal(amount)){
                this.accounts[to].deposit(amount);
            }

            //Uncomment when ready to begin task 3
            // if (shouldTest()) test();
        }

        public bool shouldTest(){
            return ++this.numTransactions % NTEST == 0;
        }

        public void test(){
            int sum = this.accounts.Sum<Account>(acc => acc.GetBalance());
            Console.WriteLine($"Total balance: {sum}");
            if (sum == this.NumAccounts * this.initialBalance){
                Console.WriteLine("Total balance unchanged");
            }
            else Console.WriteLine("Total balance changed!");
        }
    }
}