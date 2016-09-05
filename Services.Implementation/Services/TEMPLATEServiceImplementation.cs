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

        public List<UserResponse> GetPagedUsers(string uid, string pageIndex, string pageSize, string filters, string sortColumn, string sortOrder, string active)
        {
            using (var context = ResolveContext())
            {
                var business = context.GetBusinessManager().GetTEMPLATEBusiness();
                return business.GetPagedUsers(string.IsNullOrEmpty(uid) ? 0 : Int32.Parse(uid), string.IsNullOrEmpty(pageIndex) ? 1 : Int32.Parse(pageIndex), string.IsNullOrEmpty(pageSize) ? 10 : Int32.Parse(pageSize), filters, sortColumn, sortOrder, string.IsNullOrEmpty(active) ? 2 : Int32.Parse(active));
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

