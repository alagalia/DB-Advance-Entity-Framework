using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using BankSystem.Models;

namespace BankSystem.LogicLayer
{
    public class CommandsRunner
    {
        private static List<string> Parse(string input)
        {
            var commands = input.Trim().Split();
            List<string> result = new List<string>();
            if (commands[0] == "Add")
            {
                string firstCommand = commands[0] + " " + commands[1];
                result.Add(firstCommand);
                result.AddRange(commands);
                return result;
            }

            result.AddRange(commands);
            return result;

        }

        public static void ExecuteCommand(BankContext bankContext, string inputCommands)
        {
            var tokens = Parse(inputCommands);

            if (tokens[0] == "Register")
            {
                try
                {
                    CommandExecutor.ExecuteRegisterCommand(bankContext, tokens);
                }
                catch (Exception)
                {
                    string consoleResult = OutputMessageProducer.GetStringResultForRegister(inputCommands);
                    Console.WriteLine(consoleResult);
                }
                
            }
            else if (tokens[0] == "Login")
            {
                try
                {
                    CommandExecutor.ExecuteLoginCommand(bankContext,tokens);
                    string consoleResult = OutputMessageProducer.GetStringResultForLoggedIn(inputCommands);
                    Console.WriteLine(consoleResult);
                }
                catch (VerificationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else if(tokens[0] == "Logout")
            {
                try
                {
                    CommandExecutor.ExecuteLogoutCommand(tokens);
                    string consoleResult = OutputMessageProducer.GetStringResultForLogout(inputCommands);
                    Console.WriteLine(consoleResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }
            else if (tokens[0] == "Add SavingAccount")
            {
                CommandExecutor.ExecuteAddSavingAccountCommand(tokens);
            }
            else if (tokens[0] == "Add CheckingAccount")
            {
                CommandExecutor.ExecuteAddCheckingAccountCommand(tokens);
            }
            else if (tokens[0] == "ListAccounts")
            {
                CommandExecutor.ExecuteListAccountsCommand(tokens);
            }
            else if (tokens[0] == "Deposit")
            {
                CommandExecutor.ExecuteDepositCommand(tokens);
            }
            else if (tokens[0] == "Withdraw")
            {
                CommandExecutor.ExecuteWithdrawCommand(tokens);
            }
            else if (tokens[0] == "DeductFee")
            {
                CommandExecutor.ExecuteDeductFeeCommand(tokens);
            }
            else if (tokens[0] == "AddInterest")
            {
                CommandExecutor.ExecuteAddInterestCommand(tokens);
            }
        }
    }
}