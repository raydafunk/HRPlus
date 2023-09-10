using HRPlus.Application.Features.LeaveType.Commands.CreateLeaveType;
using HRPlus.Application.Features.LeaveType.Commands.DeleteLeaveType;
using HRPlus.Application.Features.LeaveType.Commands.UpdateLeaveType;
using HRPlus.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRPlus.Application.Features.LeaveType.Queries.GetLeaveTpyesDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPlus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveTypesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        // GET: api/<LeaveTypesController>
        [HttpGet]
        public async Task<List<LeaveTypeDto>>GetAllLeavetypes()
        {
            var leaveTypes = await _mediator.Send(new GetLeaveTypesQuery());
            return leaveTypes;
        }

        // GET api/<LeaveTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveTypeDetailsDto>>GetAllLeavetypesById(int id)
        {
            var leaveType = await _mediator.Send( new GetLeaveTypeDetailsQuery(id));
            return Ok(leaveType);
        }

        // POST api/<LeaveTypesController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PostLeaveTypes(CreateLeaveTypeCommand leaveType)
        {
            var response = await _mediator.Send(leaveType);
            return CreatedAtAction(nameof(GetAllLeavetypes), new { id = response });
        }

        // PUT api/<LeaveTypesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutLeaveTypes(UpdateLeaveTypeCommand leaveType)
        {
            await _mediator.Send(leaveType);
            return NoContent();
        }

        // DELETE api/<LeaveTypesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteLeaveType(int id)
        {
            var command =  new DeleteLeaveTypeCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
