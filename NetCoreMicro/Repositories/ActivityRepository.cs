using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using NetCoreMicro.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMicro.API.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase database;

        public ActivityRepository(IMongoDatabase database)
        {
            this.database = database;
        }

        public async Task AddAsync(Activity activity)
            => await Collection.InsertOneAsync(activity);

        public async Task<IEnumerable<Activity>> BrowseAsync(Guid id)
            => await Collection
                .AsQueryable()
                .Where(x => x.Id == id)
                .ToListAsync();

        public async Task<Activity> GetAsync(Guid id)
            => await Collection
                .AsQueryable()
                .FirstOrDefaultAsync(x => x.Id == id);

        private IMongoCollection<Activity> Collection
            => database.GetCollection<Activity>("Activities");
    }
}
