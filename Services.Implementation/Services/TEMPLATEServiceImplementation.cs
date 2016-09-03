using System;
using System.Data;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using Demandtec.DealManagement.Contracts.Data;
using Services.Implementation.Core;
using Service.Contracts;
using Service.Contracts.Services;
using Utility;

namespace Services.Implementation
{
    [ErrorHandlerBehavior]
    [ApplySecurityBehavior]
    [WCFMessageLoggerBehavior]
    [ArgumentValidatorAttribute]
    [ServiceBehavior(InstanceContextMode = ServiceConstants.InstanceMode)]

    public partial class TEMPLATEServiceImplementation : CoreService, ISOAPTEMPLATEApi, IRESTTEMPLATEInternalApi, IRESTTEMPLATEExternalApi
    {

        public string GetSOAPHello(string name)
        {
            using (var context = ResolveContext())
            {
                var business = context.GetBusinessManager().GetTEMPLATEBusiness();
                return business.GetHello(name);
            }
        }

        public string GetInternalRESTHello(string name)
        {
            using (var context = ResolveContext())
            {
                var business = context.GetBusinessManager().GetTEMPLATEBusiness();
                return business.GetHello(name);
            }
        }

        public string GetExternalRESTHello(string name)
        {
            using (var context = ResolveContext())
            {
                var business = context.GetBusinessManager().GetTEMPLATEBusiness();
                return business.GetHello(name);
            }
        }

        public List<UserResponse> GetUsers()
        {
            using (var context = ResolveContext())
            {
                var business = context.GetBusinessManager().GetTEMPLATEBusiness();
                return business.GetUsers();
            }
        }

        public UserResponse GetUser(string uid)
        {
            throw new NotImplementedException();
        }

        public UserResponse SaveUser(UserRequest req)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(string uid)
        {
            throw new NotImplementedException();
        }

        public void CopyUser(string uid)
        {
            throw new NotImplementedException();
        }
    }
}                                       

