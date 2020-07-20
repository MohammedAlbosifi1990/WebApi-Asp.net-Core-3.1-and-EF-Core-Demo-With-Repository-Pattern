using System;
using System.Collections.Generic;
using WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Data;

namespace WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Models
{
    public partial class Messages : IEntity
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }
        public int? UserId { get; set; }

        public virtual UserInfo User { get; set; }
    }
}
