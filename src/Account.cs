
namespace BankSim {
    public class Account {

        public volatile int Balance { get; }
        public readonly int Id { get; }

        public Account(int id, int initialBalance){
            Balance = initialBalance;
            Id = id;
        }

        public bool withdrawal(int amount){
            if (amount <= this.Balance){
                this.Balance -= amount;
                return true;
            }
            else return false;
        }

        public void deposit(int amount){
            this.Balance += amount;
        }

        public override string ToString()
        {
            return $"Account[{this.Id}] has balance {this.Balance}";
        }
    }
}
