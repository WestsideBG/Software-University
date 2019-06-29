namespace ClassBox
{
    using System;
    public class StartUp
    {
        static void Main(string[] args)
        {
            double lenght = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            try
            {
                Box box = new Box(lenght, width, height);
                double surfaceArea = box.GetSurface(box);
                double volume = box.GetVolume(box);
                double lateralSurface = box.GetLateralSurface(box);

                Console.WriteLine($"Surface Area - {surfaceArea:F2}{Environment.NewLine}Lateral Surface Area - {lateralSurface:F2}{Environment.NewLine}Volume - {volume:F2}");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
