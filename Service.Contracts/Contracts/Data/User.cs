using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Service.Contracts;

namespace Demandtec.DealManagement.Contracts.Data
{
    /// <summary>
    /// User contains complete information on Application User.
    /// </summary>
    [DataContract(Namespace = ServiceConstants.DataContractNameSpace)]
    public class UserRequest
    {
        [DataMember]
        public int uid { get; set; }
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
    }

    [DataContract(Namespace = ServiceConstants.DataContractNameSpace)]
    public class UserResponse
    {
        [DataMember]
        public int uid { get; set; }
        [DataMember]
        public string firstName { get; set; }
        [DataMember]
        public string lastName { get; set; }
        [DataMember]
        public string errorCode { get; set; }
    }

}
