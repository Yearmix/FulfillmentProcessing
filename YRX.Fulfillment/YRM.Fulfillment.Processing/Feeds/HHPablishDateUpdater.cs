using System;
using System.Threading;
using YRM.Fulfillment.Processing.Args;
using YRM.Fulfillment.Processing.Helpers;

namespace YRM.Fulfillment.Processing.Feeds
{
    public class HhPablishDateUpdater : IPublishDateUpdater
    {
        private readonly string _host;
        private readonly string _authLogin;
        private readonly string _login;
        private readonly string _password;

        public HhPablishDateUpdater(IWebSite site)
            : this(
                site.Host,
                site.AuthHost,
                site.Login,
                site.Password)
        {
        }

        public HhPablishDateUpdater(params string[] param)
            : this(
                StringHelper.ProcessArgsByName("host", param), StringHelper.ProcessArgsByName("authHost", param),
                StringHelper.ProcessArgsByName("login", param), StringHelper.ProcessArgsByName("password", param))
        {
        }

        public HhPablishDateUpdater(string host, string authHost, string login, string password)
        {
            if(string.IsNullOrEmpty(host) || string.IsNullOrEmpty(authHost) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
                throw new ArgumentException();
            _host = host;
            _authLogin = authHost;
            _login = login;
            _password = password;
        }

        public void Run()
        {
            RaiseOnComplete();
        }

        protected virtual void RaiseOnFault(Exception ex)
        {
            Volatile.Read(ref OnFault)?.Invoke(this, ex);
        }

        protected virtual void RaiseOnComplete()
        {
            Volatile.Read(ref OnComplete)?.Invoke(this, null);
        }

        public event EventHandler<Exception> OnFault;

        public event EventHandler OnComplete;
    }
}
