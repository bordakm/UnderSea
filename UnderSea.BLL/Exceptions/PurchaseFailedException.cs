using System;
using System.Runtime.Serialization;

namespace UnderSea.BLL.Services
{
    [Serializable]
    internal class PurchaseFailedException : Exception
    {
        public PurchaseFailedException(string message) : base(message)
        {

        }
    }
}