using AutoMapper;
using Debugify.Application.Commands;
using Debugify.Domain.Entity;
using Debugify.Domain.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Debugify.Application.Handlers
{
    public class AddDebuggingStepHandler : IRequestHandler<AddDebuggingStepCommand, bool>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;   

        // Injecting the correct repository to handle domain models
        public AddDebuggingStepHandler(IRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddDebuggingStepCommand command, CancellationToken cancellationToken)
        {
            if (command.Steps.Any())
            {
                var debuggingStep = _mapper.Map<DebugStepDetails>(command);

                // Saving the debugging step to the repository (ensure AddAsync is properly handled in the repository)
                await _repository.AddFeatureDebugStep(debuggingStep);
                return true;
            }

            return false;
        }
    }
}
