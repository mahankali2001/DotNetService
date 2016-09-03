using Demandtec.DealManagement.Contracts.Data;
using Service.Contracts.Data;

namespace Business.Interface
{
    using System.Collections.Generic;
    public interface ITEMPLATEBusiness : IBusiness
    {
        string GetHello(string name);
        List<UserResponse> GetUsers();
    }
}
