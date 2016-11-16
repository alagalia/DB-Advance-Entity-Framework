namespace BankSystem.Models
{
    public class SavingAccount :Account
    {
        public double InterestRate { get; set; }

        public void AddInterest(double rate)
        {
            this.InterestRate += rate;
        }
    }
}