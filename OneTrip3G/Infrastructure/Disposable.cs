﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OneTrip3G.Infrastructure
{
    class Disposable : IDisposable
    {
        private bool isDisposed;

        ~Disposable() 
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }
            isDisposed = true;
        }


        protected virtual void DisposeCore()
        {
 
        }
    }
}
