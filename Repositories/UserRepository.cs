using code_wizards_api.Data;
using code_wizards_api.Models;
using code_wizards_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace code_wizards_api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NotesSystemDbContext _dbContext;

        public UserRepository(NotesSystemDbContext notesSystemDbContext)
        {
            _dbContext = notesSystemDbContext;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<UserModel> GetById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<UserModel> Add(UserModel user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;
        }

        public async Task<UserModel> Update(UserModel user, int id)
        {
           UserModel targetUser = await GetById(id);

           if(targetUser == null)
           {
                throw new Exception($"ID Error: Não foi encontrado usuário com o ID especificado ({id}).");
           }
           
           targetUser.Name = user.Name;
           targetUser.Email = user.Email;

           _dbContext.Users.Update(user);
           await _dbContext.SaveChangesAsync();

           return targetUser;
        }

        public async Task<bool> Delete(int id)
        {
            UserModel targetUser = await GetById(id);

            if(targetUser == null)
            {
                throw new Exception($"ID Error: Não foi encontrado usuário com o ID especificado ({id}).");
            }

            _dbContext.Users.Remove(targetUser);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}