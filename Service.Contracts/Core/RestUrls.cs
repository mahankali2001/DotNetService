namespace Service.Contracts.Core
{
    public class RestUrls
    {
        /***************************************************        
         
         *  MASTER LIST OF REST URLS 
         *  DO NOT CHANGE THE FORMATING ON THIS PAGE ALIGN THEM 
         
         * /***************************************************/

        public const string RESTInternalHello = "Hello/{name}";
        public const string RESTExternalHello = "Hello/{name}";

        public const string GetUsers = "app/users/";
        public const string GetPagedUsers = "app/users/?uid={uid}&pageIndex={pageIndex}&pageSize={pageSize}&filters={filters}&sortColumn={sortColumn}&sortOrder={sortOrder}&active={active}";
        public const string GetUser = "app/users/{uid}/";
        public const string SaveUsers = "app/users/input/";
        public const string DeleteUser = "app/users/delete/{uid}/";
        public const string CopyUser = "app/users/copy/{uid}/";

        //Micoservice to  other service 
        public const string GetVendorRepsForVendor                          = "vendors/{0}/reps/?pageIndex={1}&pageSize={2}";
    }
}
