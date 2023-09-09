using HRPlus.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using HRPlus.Application.Features.LeaveAllocation.Commands.DeleteLeaveAllocation;
using HRPlus.Application.Features.LeaveAllocation.Commands.UpdateLeaveAllocation;
using HRPlus.Application.Features.LeaveAllocation.Queries.GetAllLeaveAllocations;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRPlus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveAllocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveAllocationController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<LeaveAllocationController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveAllocationDto>>> GetAllLeaveAllcationTypes(bool isLoggedInUser = false)
        {
            var leaveAllocationRequest = await _mediator.Send(new GetLeaveAllocationListQuery());
            return Ok(leaveAllocationRequest);
        }

        // GET: api/<LeaveAllocationController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<LeaveAllocationDto>>>GetAllLeaveAllcationTypesByID(int id)
        {
            var leaveAllocationRequest = await _mediator.Send(new GetLeaveAllocationListQuery());
            return Ok(leaveAllocationRequest);
        }

        // POST api/<LeaveAllocationsController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post(CreateLeaveAllocationCommand leaveAllocation)
        {
            var response = await _mediator.Send(leaveAllocation);
            return CreatedAtAction(nameof(GetAllLeaveAllcationTypes), new { id = response });
        }
        // PUT api/<LeaveAllocationsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutLeaveTypes(UpdateLeaveAllocationCommand leaveAllocationObject)
        {
            await _mediator.Send(leaveAllocationObject);
            return NoContent();
        }

        // DELETE api/<LeaveAllocationsController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteLeaveAllocationType(int id)
        {
            var command = new DeleteLeaveAllocationCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
