using System;
namespace Business.Interface
{
    public interface IBusinessManager : IDisposable
    {
        ITEMPLATEBusiness GetTEMPLATEBusiness();
    }
}
