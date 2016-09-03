using System.Collections.ObjectModel;
using Persistence.Entities.Common;

namespace Persistence.Implementation.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Persistence.Entities;
    using Persistence.Implementation.Context;
    using System.Data;
    using System.Data.Common;
    using Persistence.Implementation.Utility;
    using Persistence.Implementation.Repository.Extenstion;
    using Persistence.Interface.Repository;

    public class TEMPLATERepository : EntityRepository, ITEMPLATERepository
    {
        public TEMPLATERepository(RepositoryContext context): base(context)
        {}

        public string GetHello(string name)
        {
            // Sample code for Database Access
            // string sampleData = String.Join("," , this.Read<TEMPLATEEntity>().ToList().Select(d => d.Data));
            return String.Format("Hello {0}", name);
        }

        public DataTable GetUsers()
        {
             return this.DatabaseContext.ExecuteReader("select * from [dbo].[user]", CommandType.Text , null);
        }
    }
}

