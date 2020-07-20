using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Models;

namespace WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Services
{
    public class UploadFile
    {
        public UserInfo User { get; set; }

        //public ICollection<IFormFile> Files { get; set; }
        public List<IFormFile> Files { get; set; }
    }
}
