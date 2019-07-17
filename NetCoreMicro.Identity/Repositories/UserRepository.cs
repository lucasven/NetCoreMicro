using MongoDB.Driver;
using MongoDB.Driver.Linq;
using NetCoreMicro.Services.Identity.Domain.Models;
using NetCoreMicro.Services.Identity.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMicro.Services.Identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task<User> GetAsync(Guid id)
            => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string email)
        => await Collection
            .AsQueryable()
            .FirstOrDefaultAsync(x => x.Email == email.ToLowerInvariant());

        public async Task AddAsync(User user)
            => await Collection.InsertOneAsync(user);

        private IMongoCollection<User> Collection
            => _mongoDatabase.GetCollection<User>("User");
    }
}
