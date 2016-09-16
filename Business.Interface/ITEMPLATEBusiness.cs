using Service.Contracts.Data;

namespace Business.Interface
{
    using System.Collections.Generic;
    public interface ITEMPLATEBusiness : IBusiness
    {
        string GetHello(string name);
        List<UserResponse> GetUsers();

        List<UserResponse> GetPagedUsers(int uid, int pageIndex, int pageSize, string filters, string sortColumn,
                                    string sortOrder, int active);

        UserResponse GetUser(int uid);

        UserResponse SaveUser(UserRequest req);

        void DeleteUser(int uid);

        void CopyUser(int uid);
    }
}
