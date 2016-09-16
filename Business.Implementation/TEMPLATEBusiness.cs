using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using Business.Interface;
using Core.Logger;
using Service.Contracts.Data;
using MicroService.Models;
using Persistence.Entities;
using Persistence.Entities.Common;
using Persistence.Interface.Repository;
using Service.Contracts.Context;
using Service.Contracts.Data;
using Utility;
using Business.Implementation.Extension;

namespace Business.Implementation
{
    public partial class TEMPLATEBusiness : Business, ITEMPLATEBusiness
    {
        protected static readonly ILogger Logger = LogManager.GetLogger(typeof(TEMPLATEBusiness));
        protected static string LogIdentifier = "TEMPLATE";

        private ITEMPLATERepository repository;

        public TEMPLATEBusiness(IApplicationContext context) : base(context)
        {
            this.repository = this.DataManager.GetTEMPLATERepository();
        }

        public string GetHello(string name)
        {
            return string.Format("Message:{0}, RetailerCode:{1}, LiferayInstanceCode:{2}, RetailerEnvironmentKey:{3}, CurrentUserName: {4}", 
                this.repository.GetHello(name), CustomRequestContext.RetailerCode, CustomRequestContext.LiferayInstanceCode,  
                CustomRequestContext.RetailerEnvironmentKey, CustomRequestContext.CurrentUser.AppUserLogin);
        }

        public List<UserResponse> GetUsers()
        {
            DataTable dt = repository.GetUsers();
            List<UserResponse> urList = new List<UserResponse>();
            if (dt != null && dt.Rows.Count > 0)
            {
                return MapUserDataTableToUserResponseList(dt);
            }
            //urList.Add(MapUDTOToUserResponse(uDTO));
            
            return urList;
        }

        public List<UserResponse> GetPagedUsers(int uid, int pageIndex, int pageSize, string filters, string sortColumn, string sortOrder, int active)
        {
            DataTable dt = repository.GetPagedUsers(CustomRequestContext.AppUserId, pageIndex, pageSize, filters, sortColumn, sortOrder, active);
            List<UserResponse> urList = new List<UserResponse>();
            if (dt != null && dt.Rows.Count > 0)
            {
                return MapUserDataTableToUserResponseList(dt);
            }
            //urList.Add(MapUDTOToUserResponse(uDTO));

            return urList;
        }

        public UserResponse GetUser(int uid)
        {
            User user = repository.GetUser(uid);
            UserResponse ur = new UserResponse();
            if (user != null)
            {
                return MapUserEntityToUserResponse(user);
            }
            //urList.Add(MapUDTOToUserResponse(uDTO));

            return ur;
        }

        public void DeleteUser(int uid)
        {
            User user = repository.GetUser(uid);
            repository.DeleteUser(user);
        }

        public void CopyUser(int uid)
        {
            User user = repository.GetUser(uid);
            repository.CopyUser(user);
        }

        public UserResponse SaveUser(UserRequest ur)
        {
            User user = MapUserRequestToUser(ur);
            if(user.uid > 0)
            {
                repository.Save(user);
            }
            else
            {
                repository.Save(user);    
            }
            
            return MapUserEntityToUserResponse(user);
        }

        public List<UserResponse> MapUserDataTableToUserResponseList(DataTable u)
        {
            List<UserResponse> urList = new List<UserResponse>();
            foreach (DataRow dr in u.Rows)
            {
                UserResponse ur = new UserResponse();
                ur.uid = int.Parse(dr["uid"].ToString());
                ur.firstName = dr["firstName"].ToString();
                ur.lastName = dr["lastName"].ToString();
                urList.Add(ur);
            }
            return urList;
        }

        public UserResponse MapUDTOToUserResponse(UserDTO u)
        {
           return new UserResponse()
                                  {
                                      uid = u.uid,
                                      firstName = u.firstName,
                                      lastName = u.lastName
                                  };
        }

        public UserResponse MapUserEntityToUserResponse(User u)
        {
            return new UserResponse()
            {
                uid = u.uid,
                firstName = u.firstName,
                lastName = u.lastName
            };
        }

        public User MapUserRequestToUser(UserRequest ur)
        {
            return new User()
            {
                uid = ur.uid,
                firstName = ur.firstName,
                lastName = ur.lastName
            };
        }
    }
}
