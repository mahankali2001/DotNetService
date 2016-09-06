using System;
using System.Data.Entity;
//using System.Data.Objects;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using System.Data.Common;
using Persistence.Entities;
using Persistence.Entities.Common;
using DBEntities = Persistence.Entities.Common;

namespace Persistence.Implementation.Context
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbConnection connection): base(connection, false)
        {
            Database.SetInitializer<RepositoryContext>(null);
            Configuration.LazyLoadingEnabled = false;
            this.databaseContext = new DatabaseContext(this);
        }

        private IDatabaseContext databaseContext;
        public IDatabaseContext DatabaseContext
        {
            get 
            {
                return this.databaseContext; 
            }
        }


        #region Public methods
        public IQueryable<T> Read<T>() where T : class
        {
            return this.Set<T>().AsNoTracking();
        }

        public DbSet<T> Write<T>() where T : class
        {
            return this.Set<T>();
        }
        #endregion

        #region Protected methods
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.HasDefaultSchema("calendar");

            #region Register Entities

            //modelBuilder.Entity<TEMPLATEEntity>();
            modelBuilder.Entity<User>();

            //modelBuilder.Entity<CommonDeal>().HasRequired(c => c.MasterDeal).WithMany(c => c.LocationDeals).HasForeignKey(c => c.MasterDealID);

            //modelBuilder.Entity<CommonDeal>().Property(c => c.VendorAttributes.Name).HasColumnName("VendorName");

            //modelBuilder.Entity<CostChangeLocationSetItems>().Property(c => c.NewCost1).HasColumnName("NewCost1").HasPrecision(18, 4);

            //modelBuilder.Entity<UserSignup>().Property(c => c.Audit.CreateDateTime).HasColumnName("CreateDatetime");
            //modelBuilder.Entity<UserSignup>().Property(c => c.Audit.CreatedBy).HasColumnName("CreatedBy");
            //modelBuilder.Entity<UserSignup>().Property(c => c.Audit.UpdatedDateTime).HasColumnName("UpdatedDateTime");
            //modelBuilder.Entity<UserSignup>().Property(c => c.Audit.UpdatedBy).HasColumnName("UpdatedBy");

            modelBuilder.HasDefaultSchema("dbo").Entity<DBEntities.EmailAttributes>();
            //modelBuilder.Entity<DBEntities.EmailAttributes>();
            #endregion
        }
        #endregion
    }
}