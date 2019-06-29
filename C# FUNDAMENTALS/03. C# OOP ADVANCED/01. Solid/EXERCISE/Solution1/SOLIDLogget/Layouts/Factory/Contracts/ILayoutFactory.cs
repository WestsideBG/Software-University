namespace SOLIDLogger.Layouts.Factory.Contracts
{
    using SOLIDLogger.Layouts.Contracts;

    public interface ILayoutFactory
    {
        ILayout CreateLayout(string type);
    }
}