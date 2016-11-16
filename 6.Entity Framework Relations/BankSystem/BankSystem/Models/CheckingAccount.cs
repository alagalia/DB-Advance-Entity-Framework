namespace BankSystem.Models
{
    public class CheckingAccount :Account
    {
        public decimal Fee { get; set; }

        public void DeductFee(decimal fee)
        {
            this.Fee -= fee;
        }
    }
}