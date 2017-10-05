using System;

namespace YRM.Fulfillment.Processing
{
    internal interface IRunable
    {
        event EventHandler<Exception> OnFault;

        event EventHandler OnComplete;
        
        void Run();
    }
}
