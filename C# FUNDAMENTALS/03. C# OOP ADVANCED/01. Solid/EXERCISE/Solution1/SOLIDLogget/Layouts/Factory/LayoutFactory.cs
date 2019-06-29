namespace SOLIDLogger.Layouts.Factory
{
    using System;
    using SOLIDLogger.Layouts.Contracts;
    using Contracts;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            string typeToLower = type.ToLower();

            switch (typeToLower)
            {
                case "simplelayout":
                    return new SimpleLayout();
                case "xmllayout":
                    return  new XmlLayout();
                default:
                    throw new ArgumentException("Invalid layout type!");
            }
        }
    }
}