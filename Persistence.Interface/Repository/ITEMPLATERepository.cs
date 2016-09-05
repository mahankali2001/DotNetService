
using System.Data;
using Persistence.Entities;
using DataBaseEntities = Persistence.Entities.Common;
namespace Persistence.Interface.Repository
{
    using System;
    using System.Collections.Generic;

    public interface ITEMPLATERepository : IEntityRepository
    {
        string GetHello(string name);
        DataTable GetUsers();

        DataTable GetPagedUsers(int uid, int pageIndex, int pageSize, string filters, string sortColumn,
                           string sortOrder, int active);
    }
}
