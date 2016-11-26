using PhotoShare.Client.Attributes;
using PhotoShare.Client.Interfaces;
using PhotoShare.Data.Intefaces;

namespace PhotoShare.Client.Core.Commands
{
    public abstract class Command : IExecutable
    {
        [Inject]
        protected IUnitOfWork unit;

        private string[] data;

        protected Command(string[] data)
        {
            this.Data = data;
        }

        protected string[] Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public abstract string Execute();
        public void CommitChanges()
        {
            this.unit.Save();
        }
    }
}
