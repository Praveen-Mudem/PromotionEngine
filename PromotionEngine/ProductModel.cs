using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromotionEngine
{
    public class ProductRuleData : BaseDispose
    {
        public string RuleType { get; set; }
        public string Product1 { get; set; }
        public string Product2 { get; set; }
        public int Quantity { get; set; }
        public decimal FixedPrice { get; set; }
    }
    public class ProductData : BaseDispose
    {
        public string ProductText { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal CaltulatedPrice { get; set; }
    }
  
    public class BaseDispose : IDisposable
    {
        // Flag: Has Dispose already been called?
        bool disposed = false;

        // Instantiate a SafeHandle instance.
        System.Runtime.InteropServices.SafeHandle handle = new Microsoft.Win32.SafeHandles.SafeFileHandle(IntPtr.Zero, true);

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing && handle != null)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }
    }
}
