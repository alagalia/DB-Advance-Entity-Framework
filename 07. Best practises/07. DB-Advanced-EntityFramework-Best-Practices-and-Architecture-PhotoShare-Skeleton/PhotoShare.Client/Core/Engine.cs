﻿using PhotoShare.Client.Interfaces;
using System;


namespace PhotoShare.Client.Core
{
    class Engine : IRunnable
    {
        private ICommandDispatcher commandDispatcher;
        private IReader reader;
        private IWriter writer;
        public Engine(ICommandDispatcher commandDispatcher, IReader reader, IWriter writer)
        {
            this.commandDispatcher = commandDispatcher;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run(string start)
        {
            writer.WriteLine("Program started");
            while (true)
            {
                try
                {
                    string input = reader.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    IExecutable command = this.commandDispatcher
                        .DispatchCommand(commandName, data);
                    string result = command.Execute();
                    //command.CommitChanges();
                    this.writer.WriteLine(result);
                }
                catch (Exception e)
                {
                    writer.WriteLine(e.Message);
                }
            }
        }
    }
}
