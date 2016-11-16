namespace BillsPaymentSystem
{
    class SystemMain
    {
        static void Main()
        {
            //----------create only class People in DB. !!! Nothing in modelBuilder.
            TPHuniversityContext tphContext = new TPHuniversityContext();
            tphContext.Database.Initialize(true);


            //--------------create separated tables. One for Student and one for Teacher
            TpTuniversityContext tptContext = new TpTuniversityContext();
            tptContext.Database.Initialize(true);

            //-----------Without inheritance. Put all props into the entity.
            TPCuniversityContext tpcContext = new TPCuniversityContext();
            tpcContext.Database.Initialize(true);
        }
    }
}
