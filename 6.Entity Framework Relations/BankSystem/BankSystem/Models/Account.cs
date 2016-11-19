using System.ComponentModel.DataAnnotations;

namespace BankSystem.Models
{
    public abstract class Account
    {
        [Key]
        public int Number { get; set; }

        public decimal Balance { get; set; }

        public void DepositMoney(decimal depositAmount)
        {
            Balance += depositAmount;
        }

        public void WithdrawMoney(decimal money)
        {
            Balance -= money;
        }

        public virtual User User{ get; set; }
    }
}