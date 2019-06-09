using NetCoreMicro.Common.Exceptions;
using NetCoreMicro.Services.Activities.Domain.Models;
using NetCoreMicro.Services.Activities.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMicro.Services.Activities.Services
{
    public class ActivityService : IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ActivityService(IActivityRepository activityRepository, ICategoryRepository categoryRepository)
        {
            _activityRepository = activityRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var activityCategory = await _categoryRepository.GetAsync(name);
            if(activityCategory == null)
            {
                throw new NetCoreMicroException("category_not_found", $"Category: '{category} was not found.");
            }
            var activity = new Activity(id, activityCategory, userId, name, description, createdAt);
        }
    }
}
