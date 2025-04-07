using AutoMapper;
using Debugify.Application.Commands;
using Debugify.Domain.Entity;
using Debugify.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debugify.Application.Handlers
{
    public class FeatureNameHandler : IRequestHandler<FeatureNameCommand, IEnumerable<DebugStepDetails>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;
        public FeatureNameHandler(IRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<DebugStepDetails>> Handle(FeatureNameCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request != null)
                {
                    var command = _mapper.Map<FeatureNameCommand, FeatureName>(request);
                    var result = await _repository.GetFeatureeDebugSteps(command);
                    return result;

                }

            }
            catch (Exception ex) { 
                throw ex; 
            }
            return null;
        }
    }
}
