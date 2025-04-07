using Debugify.Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debugify.Application.Commands
{
    public class FeatureNameCommand:IRequest<IEnumerable<DebugStepDetails>>
    { 
        public string FeatureName { get; set; } 
    }
}
