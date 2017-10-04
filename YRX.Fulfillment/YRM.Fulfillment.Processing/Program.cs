using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;
using Ninject.Parameters;
using YRM.Fulfillment.Processing.Feeds;
using YRM.Fulfillment.Processing.Helpers;
using YRM.Fulfillment.Processing.Modules;

namespace YRM.Fulfillment.Processing
{
    internal class Program
    {
        private static IKernel _kernel;

        private static T Start<T>(params string[] param)
        {
            return _kernel.Get<T>(new ConstructorArgument("param", param));
        }

        //DI of the brainfuck
        public IDictionary<string, Func<string[], IRunable>> Actions = new Dictionary<string, Func<string[], IRunable>>()
        {
            {"updatecv", param => Start<IPublishDateUpdater>()},
            {"updatecvwithparam", Start<IPublishDateUpdater>}
        };

        public Program()
        {
            _kernel = new StandardKernel(NinjectModules.Modules);
        }

        private static void Main(string[] args)
        {
            var exec = new Program();
            var action = args.Length > 0 ? StringHelper.ProcessArgs(args[0]).ToLower() : string.Empty;
            var param = args.Length > 1 ? args.Skip(1).ToArray() : null;

            try
            {
                exec.PerformAction(action, param);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        public void PerformAction(string action, params string[] param)
        {
            if (!Actions.ContainsKey(action))
                throw new ArgumentException("Invalid parameter", nameof(action));
            var exec = Actions[action](param);
            exec.Run();
        }
    }
}
