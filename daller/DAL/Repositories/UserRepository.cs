using Common_Layer.Models.Dtos;
using Common_Layer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using ProyectoMerck.DAL;
using ProyectoMerck.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_layer.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>
    {

        private readonly DbSet<User> _set;

        public UserRepository(AppDbContext context) : base(context)
        {

            _set = context.Users;

        }

        public async Task<User> UserLogin(LoginDto dto)
        {

            User foundUser = await _set.Where(u => dto.UserName == u.UserName && dto.Password == u.Password).FirstOrDefaultAsync();

            return foundUser;
        
        }

    }
}
