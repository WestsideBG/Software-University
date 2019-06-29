namespace Telephony
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();
            string[] urls = Console.ReadLine().Split();

            Smartphone phone = new Smartphone();

            try
            {
                foreach (var number in numbers)
                {
                    Console.WriteLine(phone.Calling(number));
                }

                foreach (var url in urls)
                {
                    Console.WriteLine(phone.Browsing(url));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
