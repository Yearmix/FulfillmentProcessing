using System;
using System.Configuration;

namespace YRM.Fulfillment.Processing.Args
{
    public class HHWebSite : IWebSite
    {
        private string _host = ConfigurationManager.AppSettings.Get("HH.Host");

        private string _authHost = ConfigurationManager.AppSettings.Get("HH.AuthHost");

        private string _login = ConfigurationManager.AppSettings.Get("HH.Login");

        private string _password = ConfigurationManager.AppSettings.Get("HH.Password");

        public string Host
        {
            get { return _host; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _host = value;
                }
            }
        }

        public string AuthHost
        {
            get { return _authHost; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _authHost = value;
                }
            }
        }
        public string Login
        {
            get { return _login; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _login = value;
                }
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _password = value;
                }
            }
        }
    }
}
