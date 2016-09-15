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

        public DataTable GetPagedUsers(int uid, int pageIndex, int pageSize, string filters, string sortColumn, string sortOrder, int active)
        {
            
            
            return this.DatabaseContext.ExecuteReader("GetUsers", CommandType.StoredProcedure,
                                                                  this.DatabaseContext.CreateParameter("@PageIndex", pageIndex),
                                                                  this.DatabaseContext.CreateParameter("@PageSize", pageSize),
                                                                  this.DatabaseContext.CreateParameter("@FilterData", filters),
                                                                  this.DatabaseContext.CreateParameter("@SortColumn", sortColumn),
                                                                  this.DatabaseContext.CreateParameter("@SortOrder", sortOrder),                                                  
                                                                  this.DatabaseContext.CreateParameter("@UserId", uid),
                                                                  this.DatabaseContext.CreateParameter("@Active", active)
                );
        }

        //public AppUser GetAppUser(int appUserId, params string[] includes)
        //    {
        //        var entitySet = from au in this.Read<AppUser>().Includes(includes)
        //                        where au.AppUserId == appUserId
        //                        select au;
        //        return entitySet.FirstOrDefault();
        //    }

        //public DTOPage<VendorOnBoardingResponse> GetVendorOnBoarding(int pageIndex, int pageSize, VendorOnBoardingStatus status = VendorOnBoardingStatus.None)
        //    {
        //        return VendorOnBoardingBusiness.Initalize(this)
        //            .GetNewVendorOnBoardingRecords(pageIndex, pageSize, status)
        //            .ToMessage();
        //    }

        //public VendorOnBoardingBusiness GetNewVendorOnBoardingRecords(int pageindex = 1, int pagesize = 10, VendorOnBoardingStatus status = VendorOnBoardingStatus.None)
        //{
        //    //List<int> listOfUserRetailers = _infrastructureRepository.GetUserRetailerAssocated(DMContext.PartyId) ?? new List<int>();
        //    List<int> listOfUserRetailers = GetRetailersAssociated();
        //    PagedResult<VendorOnBoarding> vob = _infrastructureRepository.GetNewVendorOnBoardingRecords(status, listOfUserRetailers, pageindex, pagesize);
        //    this.VendorOnBoardingCollections = ConvertToPageResultDTO(vob);
        //    return this;
        //}

        //public PagedResult<VendorOnBoarding> GetNewVendorOnBoardingRecords(VendorOnBoardingStatus status, List<int> retailPartyId, int pageindex = 0, int pagesize = 10)
        //{
        //    if (status == VendorOnBoardingStatus.None)
        //    {
        //        if (retailPartyId.Count != 0)
        //        {
        //            var r1 =
        //                from row in
        //                    this.Read<VendorOnBoarding>().Where(
        //                        x =>
        //                        (retailPartyId.Contains(x.RetailPartyId) &&
        //                         ((x.VendorOnBoardingStatusId != (byte)VendorOnBoardingStatus.CancelInvitation) &&
        //                          (x.VendorOnBoardingStatusId != (byte)VendorOnBoardingStatus.Approve))
        //                        ))
        //                orderby row.LastSentDateTime descending
        //                select row;
        //            PagedResult<VendorOnBoarding> r1Result = Pager<VendorOnBoarding>.GetResult(r1, pageindex, pagesize);
        //            return r1Result;
        //        }
        //        else
        //        {
        //            IQueryable<VendorOnBoarding> r3 = from row in
        //                                                  this.Read<VendorOnBoarding>().Where(
        //                                                      x => (((x.VendorOnBoardingStatusId != (byte)VendorOnBoardingStatus.CancelInvitation) &&
        //                                                        (x.VendorOnBoardingStatusId !=
        //                                                         (byte)VendorOnBoardingStatus.Approve))
        //                                                      ))
        //                                              orderby row.LastSentDateTime descending
        //                                              select row;
        //            PagedResult<VendorOnBoarding> r1Result = Pager<VendorOnBoarding>.GetResult(r3, pageindex, pagesize);
        //            return r1Result;
        //        }
        //    }
        //    else
        //    {
        //        var s = new List<int> { (int)status };
        //        var r2 = from row in
        //                     this.Read<VendorOnBoarding>().Where(x => s.Contains(x.VendorOnBoardingStatusId) && retailPartyId.Contains(x.RetailPartyId))
        //                 orderby row.LastSentDateTime descending
        //                 select row;
        //        PagedResult<VendorOnBoarding> result = Pager<VendorOnBoarding>.GetResult(r2, pageindex, pagesize);
        //        return result;
        //    }
        //}

        //internal static PagedResult<T> GetResult(IQueryable<T> query, int pageIndex, int pageSize)
        //{
        //    var result = new PagedResult<T> { CurrentPage = pageIndex, PageSize = pageSize, RowCount = query.Count() };
        //    double pageCount = (double)result.RowCount / pageSize;
        //    result.PageCount = (int)Math.Ceiling(pageCount);
        //    int skip = (pageIndex - 1) * pageSize;
        //    result.Results = query.Skip(skip).Take(pageSize).ToList();
        //    return result;
        //}

        public User GetUser(int uid)
        {
            //return this.DatabaseContext.ExecuteReader("select * from [dbo].[user] where uid=" + uid, CommandType.Text, null);
            var users = from u in this.Read<User>()
                        where u.uid == uid
                        select u;
            return users.ToList().FirstOrDefault();
        }        

        public void DeleteUser(Entities.User user)
        {
            base.DeleteEntity(user);
        }

        public void Save(Entities.User entity)
        {
            this.SaveEntityWithAutoId(entity, entity.uid);
        }
    }
}

