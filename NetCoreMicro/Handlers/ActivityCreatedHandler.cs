using NetCoreMicro.API.Models;
using NetCoreMicro.API.Repositories;
using NetCoreMicro.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMicro.API.Handlers
{
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated>
    {
        private readonly IActivityRepository activityRepository;

        public ActivityCreatedHandler(IActivityRepository activityRepository)
        {
            this.activityRepository = activityRepository;
        }

        public async Task HandleAsync(ActivityCreated @event)
        {
            await activityRepository.AddAsync(new Activity
            {
                Id = @event.ID,
                Name = @event.Name,
                Category = @event.Category,
                CreatedAt = @event.CreatedAt,
                Description =  @event.Description,
                User = @event.UserId
            });
            Console.WriteLine($"Activity created: {@event.Name}");
        }
    }
}
