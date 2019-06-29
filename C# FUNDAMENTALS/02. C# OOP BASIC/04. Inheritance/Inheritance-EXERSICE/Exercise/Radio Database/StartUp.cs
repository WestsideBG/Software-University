namespace RadioDatabase
{
    using Radio_Database.Core;
    using RadioDatabase.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {

            Engine engine = new Engine();
            engine.Run();


        }

     
    }
}
