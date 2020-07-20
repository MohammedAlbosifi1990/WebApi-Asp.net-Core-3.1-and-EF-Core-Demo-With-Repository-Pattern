using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Data;

namespace WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Models
{
    public partial class UserInfo :IEntity
    {
        public UserInfo()
        {
            Messages = new HashSet<Messages>();
        }

        [Column("UserId")]
        public int Id { get; set; }
        //public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Messages> Messages { get; set; }

    }
}
