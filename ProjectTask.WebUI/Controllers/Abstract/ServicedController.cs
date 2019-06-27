using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTask.WebUI.Controllers.Abstract
{
    public abstract class ServicedController<TService> : DefaultController where TService : class
    {
        public TService Service { get; }

        protected ServicedController(TService service)
        {
            Service = service;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Service is IDisposable s)
                {
                    s.Dispose();
                }
            }

            base.Dispose(disposing);
        }
    }
}