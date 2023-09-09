
using HRPlus.Application.Features.LeaveRequest.Commands.CancelLeaveRequest;
using HRPlus.Application.Features.LeaveRequest.Commands.ChangeLeaveRequest;
using HRPlus.Application.Features.LeaveRequest.Commands.CreateLeaveRequest;
using HRPlus.Application.Features.LeaveRequest.Queries.GetLeaveRequestDetail;
using HRPlus.Application.Features.LeaveRequest.Queries.GetLeaveRequestList;
using HRPlus.Application.Features.LeaveType.Commands.DeleteLeaveType;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRPlus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRquestController : ControllerBase
    {
        private readonly IMediator _meadiator;

        public LeaveRquestController(IMediator meadiator)
        {
            _meadiator = meadiator;
        }

        // GET: api/<LeaveRequestsController>
        [HttpGet]
        public async Task<ActionResult<List<LeaveRequestListDto>>> GetLeaveRequests(bool isLoggedUser = false)
        {
            var leaveRequestsObject = await _meadiator.Send(new GetLeaveRequestListQuery());
            return Ok(leaveRequestsObject);
        }

        // GET api/<LeaveRequestsController>/5
        [HttpGet("{id   }")]
        public async Task<ActionResult<LeaveRequestListDto>> GetLeaveRequestByID(int Id)
        {
            var leaveRequestsObject = await _meadiator.Send(new GetLeaveRequesDetailsQuery { Id = Id });
            return Ok(leaveRequestsObject);
        }

        // POST api/<LeaveRequestsController>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> PostLeveRequests(CreateLeaveRequestCommand createLeaveRequest)
        {
            var response = await _meadiator.Send(createLeaveRequest);
            return CreatedAtAction(nameof(GetLeaveRequests), new { id = response });
        }

        // PUT api/<LeaveRequestsController>/5
        [HttpPut]
        [Route("CancelRequest")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> CancelLeaveRequest(CancelLeaveRequestCommand cancelRequest)
        {
            await _meadiator.Send(cancelRequest);
            return NoContent();
        }

        // PUT api/<LeaveRequestsController>/UpdateApproval/
        [HttpPut]
        [Route("UpdateApproval")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateApprovelLeaveRequest(ChangeLeaveRequestApprovalCommand updateRequest)
        {
            await _meadiator.Send(updateRequest);
            return NoContent();
        }

        // DELETE api/<LeaveRequestsController>/5
        [HttpDelete("{Id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]

        public async Task<ActionResult> DeleteLeaveRequest(int id)
        {
            var deleatcommandObject = new DeleteLeaveTypeCommand { Id = id };
            await _meadiator.Send(deleatcommandObject);
            return NoContent();
        }
    }
}
