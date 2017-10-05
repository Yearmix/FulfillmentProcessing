namespace YRM.Fulfillment.Processing.Args
{
    public interface IWebSite
    {
        string Host { get; set; }
        string AuthHost { get; set; }
        string Login { get; set; }
        string Password { get; set; }
    }
}
