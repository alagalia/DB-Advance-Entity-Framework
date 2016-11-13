
using StudentSystem.Data;

namespace StudentSystem.ConsoleClient
{
    class StudentSystemMain
    {
        static void Main()
        {
            StudentSystemContext context = new StudentSystemContext();
            context.Database.Initialize(true);
        }
    }
}
