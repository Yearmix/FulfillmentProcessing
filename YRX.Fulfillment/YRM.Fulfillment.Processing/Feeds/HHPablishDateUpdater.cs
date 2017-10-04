using System;
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
                StringHelper.ProcessArgs(param[0]), StringHelper.ProcessArgs(param[0]),
                StringHelper.ProcessArgs(param[0]), StringHelper.ProcessArgs(param[0]))
        {
        }

        public HhPablishDateUpdater(string host, string authHost, string login, string password)
        {
            _host = host;
            _login = login;
            _password = password;
            _authLogin = authHost;
        }

        public void Run()
        {
            throw new NotImplementedException();
        }
    }
}
