using Microsoft.Extensions.Logging;
using NetCoreMicro.Common.Commands;
using NetCoreMicro.Common.Events;
using NetCoreMicro.Common.Exceptions;
using NetCoreMicro.Services.Activities.Services;
using RawRabbit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreMicro.Services.Activities.Handlers
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _busClient;
        private readonly IActivityService _activityService;
        private ILogger _logger;

        public CreateActivityHandler(IBusClient busClient,
            IActivityService activityService,
            ILogger<CreateActivityHandler> logger)
        {
            _busClient = busClient;
            _activityService = activityService;
            _logger = logger;
        }

        public async Task HandleAsync(CreateActivity command)
        {
            _logger.LogInformation($"Creating activity: {command.Name}");
            try
            {
                await _activityService.AddAsync(command.ID, command.UserId, command.Category, 
                    command.Name, command.Description, command.CreatedAt);

                await _busClient.PublishAsync(new ActivityCreated(command.ID, command.UserId, 
                    command.Category, command.Name, command.Description));
            }
            catch(NetCoreMicroException ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.ID,
                    ex.Code, ex.Message));
                _logger.LogInformation(ex.Message);
            }
            catch (Exception ex)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.ID,
                    "error", ex.Message));
                _logger.LogInformation(ex.Message);
            }

        }
    }
}
