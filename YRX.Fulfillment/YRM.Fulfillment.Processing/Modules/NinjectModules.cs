using System;
using Ninject.Modules;
using YRM.Fulfillment.Processing.Args;
using YRM.Fulfillment.Processing.Feeds;

namespace YRM.Fulfillment.Processing.Modules
{
    public class NinjectModules
    {
        public static INinjectModule[] Modules => new INinjectModule[] { new MainModule() };

        public class MainModule : NinjectModule
        {
            public override void Load()
            {
                Bind<IPublishDateUpdater>().To<HhPablishDateUpdater>();
                Bind<IWebSite>().To<HHWebSite>();
            }
        }
    }
}
