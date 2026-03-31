using System.Collections.ObjectModel;
using Microsoft.Extensions.Logging;
using State.Core.Dtos;
using State.Persistence;
using State.Core.Requests;
using Microsoft.EntityFrameworkCore;
using State.Persistence.Configurations;

namespace State.Services
{
    public class StateService
    {
        private readonly AppDbContext _dbContext;
        private readonly ILogger<StateService> _logger;

        public StateService(AppDbContext dbContext, ILogger<StateService> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger;
        }

        public IEnumerable<StateDto> GetStateList()
        {
            IList<StateDto> states = _dbContext.States
    .Select(state => new StateDto(state.Id, state.Name, state.Code))
    .ToArray();

            return new ReadOnlyCollection<StateDto>(states);
        }

        public StateDto Create(CreateSateRequest request)
        { 

            var state = new States
            {
                Name = request.Name,
                Code = request.Code,
            };

            _dbContext.States.Add(state);
            _dbContext.SaveChanges();

            return _dbContext.States
                .Where(b => b.Id == state.Id)
                .Select(b => new StateDto(
                    b.Id,
                    b.Name,
                    b.Code 
                ))
                .First();
        }
    }
}