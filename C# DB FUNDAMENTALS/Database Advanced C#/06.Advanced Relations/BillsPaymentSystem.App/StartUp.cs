using System;
using BillsPaymentSystem.Data;

namespace BillsPaymentSystem.App
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                context.Database
                    .EnsureDeleted();

                context.Database.EnsureCreated();

               DbInitializer initializer = new DbInitializer(context);

                context.Database.EnsureDeleted();
            }
        }
    }
}
