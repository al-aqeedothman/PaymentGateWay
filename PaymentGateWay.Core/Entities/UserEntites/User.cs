using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace PaymentGateWay.Core.Entities
{
  public  class User : BaseEntity
    {
        
        [Required]
        [MaxLength(100)]
        public string LoginName { get; set; }

        [ForeignKey("UserTypeId")]
        [Required]
        public long UserTypeId { get; set; }

        [Required]
        [MaxLength(100)]
        [JsonIgnore]
        public string Password { get; set; }

        [Required]
        [ForeignKey("UserStatusId")]
        public long UserStatusId { get; set; }


        [ForeignKey("IndiviualAccountId")]
        public long? IndiviualAccountId { get; set; }


        [ForeignKey("CompanyAccountId")]
        public long? CompanyAccountId { get; set; }


        public UserType UserType { get; set; }

        public UserStatus UserStatus { get; set; }
        public string RefreshToken { get; set; }

        public  CompanyAccount CompanyAccount { get; set; }
        public IndiviualAccount IndiviualAccount { get; set; }

        public  ICollection<Transaction> Transactions { get; set; }


    }
}
