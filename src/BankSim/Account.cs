
namespace BankSim {
    public class Account {

        private volatile int balance;
        public int Id { get; }

        public Account(int id, int initialBalance){
            this.balance = initialBalance;
            Id = id;
        }

        public bool withdrawal(int amount){
            if (amount <= this.balance){
                this.balance -= amount;
                return true;
            }
            else return false;
        }

        public void deposit(int amount){
            this.balance += amount;
        }

        public int GetBalance(){
            return this.balance;
        }

        public override string ToString()
        {
            return $"Account[{this.Id}] has balance {this.balance}";
        }
    }
}
