using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Data.EFCore;
using WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Models;

namespace WebApi_Asp.net_Core_3._1_and_EF_Core_Demo.Data.Repository
{
    public class UserRepo : EfCoreRepository<UserInfo, DemoDBContext>
    {
        public readonly DbContext dbContext;
        public UserRepo(DemoDBContext context) : base(context)
        {
            dbContext = context;
        }

        public async Task<IEnumerable<UserInfo>> GetWithInclude()
        {
            Expression<Func<UserInfo, ICollection<Messages>>> expression = (t => t.Messages);
            return await dbContext.Set<UserInfo>().Include(expression).ToListAsync();
        }
    }
}
