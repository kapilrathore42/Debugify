using Azure;
using Debugify.Application.Commands;
using Debugify.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DebuggingMicroservice.Controllers
{
    [Route("api/debugging/features")]
    [ApiController]
    public class AddNewFeatureDebugStepController : ControllerBase
    {
        private static readonly Dictionary<string, List<DebuggingStep>> featureSteps = new();
        public readonly IMediator _mediator;

        public AddNewFeatureDebugStepController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // POST api/debugging/features/{featureName}/steps
        [HttpPost]
        public IActionResult AddFeatureDebugStep([FromBody] AddDebuggingStepCommand request)
        {
            if (request!=null)
            {
                _mediator.Send(request);
            }

            return CreatedAtAction(nameof(GetFeatureeDebugSteps), new { featureName = request.FeatureName }, request.IssueDescription);
        }

        // GET api/debugging/features/{featureName}/steps
        [HttpGet]
        public async Task<IActionResult> GetFeatureeDebugSteps([FromQuery] FeatureNameCommand feature)
        {
           

            try
            {
                var response = await _mediator.Send(feature);
                if (response == null)
                {
                    return NotFound("No debug steps found for the given feature.");
                }

                return Ok(response);
            }
            catch (Exception ex)
            {
                // Log exception (optional)
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT api/debugging/features/{featureName}/steps/{stepId}
        [HttpPut("{stepId}")]
        public IActionResult UpdateStep(string featureName, int stepId, [FromBody] DebuggingStep step)
        {
            if (!featureSteps.ContainsKey(featureName) || stepId < 0 || stepId >= featureSteps[featureName].Count)
            {
                return NotFound("Step not found.");
            }

            featureSteps[featureName][stepId] = step;
            return NoContent();
        }
    }

    public class DebuggingStep
    {
        public string IssueDescription { get; set; }
        public string Steps { get; set; }
        public string Tags { get; set; }
    }
}
