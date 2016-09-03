using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using Business.Implementation;
using Business.Interface;

namespace Business.Implementation
{
    public class BusinessManager : IBusinessManager
    {
        
        private IApplicationContext context;

        public BusinessManager(IApplicationContext context)
        {
            this.context = context;
        }

        public ITEMPLATEBusiness GetTEMPLATEBusiness()
        {
            return new TEMPLATEBusiness(this.context);
        }

        public void Dispose()
        {
   
        }
    }
}
