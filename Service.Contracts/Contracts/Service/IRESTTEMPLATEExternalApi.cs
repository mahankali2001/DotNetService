using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using Demandtec.DealManagement.Contracts.Data;
using Service.Contracts.Core;

namespace Service.Contracts.Services
{
    [ServiceContract(Namespace = ServiceConstants.ServiceNameSpace)]
    public interface IRESTTEMPLATEExternalApi
    {
        [OperationContract(Name = "GetRESTExternalHello")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = RestUrls.RESTExternalHello, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string GetExternalRESTHello(string name);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = RestUrls.GetUsers, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<UserResponse> GetUsers();

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = RestUrls.GetPagedUsers, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<UserResponse> GetPagedUsers(string uid, string pageIndex, string pageSize, string filters, string sortColumn, string sortOrder, string active);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = RestUrls.GetUser, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UserResponse GetUser(string uid);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped,
                  Method = "POST",
                  UriTemplate = RestUrls.SaveUsers,
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json)]
        UserResponse SaveUser(UserRequest req);

        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped, Method = "DELETE", UriTemplate = RestUrls.DeleteUser, RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void DeleteUser(string uid);

        [OperationContract]
        [WebGet(BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = RestUrls.CopyUser,
            RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        void CopyUser(string uid);
    }
}
