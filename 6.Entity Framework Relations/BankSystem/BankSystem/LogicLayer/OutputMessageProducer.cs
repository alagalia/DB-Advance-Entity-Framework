using System;

namespace BankSystem.LogicLayer
{
    public static class OutputMessageProducer
    {
        public static string GetStringResultForRegister(string input)
        {
            var tokens = input.Split();
            return tokens[1] + " was registered in the system";
        }
        public static string GetStringResultForLoggedIn(string input)
        {
            var tokens = input.Split();
            return "Succesfully logged in " + tokens[1];
        }

        public static string GetStringResultForLogout(string input)
        {
            var tokens = input.Split();
            return $"User {tokens[1]} successfully logged out";
        }
    }
}