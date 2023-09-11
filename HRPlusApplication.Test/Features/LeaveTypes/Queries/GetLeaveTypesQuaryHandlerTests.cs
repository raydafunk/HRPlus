using AutoMapper;
using HRPlus.Application.Contracts.Logging;
using HRPlus.Application.Contracts.Presistence;
using HRPlus.Application.Features.LeaveType.Queries.GetAllLeaveTypes;
using HRPlus.Application.MappingProfile;
using HRPlusApplication.Test.Mocks;
using Moq;
using Shouldly;

namespace HRPlusApplication.Test.Features.LeaveTypes.Queries
{
    public class GetLeaveTypesQuaryHandlerTests
    {
            private readonly Mock<ILeaveTypeRepository> _mockRepo;
            private IMapper _mapper;
            private Mock<IAppLogger<GetLeaveTypesQueryHandler>> _mockAppLogger;

        public GetLeaveTypesQuaryHandlerTests()
        {
            _mockRepo = MockLeaveTypeRepository.GetMockLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<LeaveTypeProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetLeaveTypesQueryHandler>>();
        }

        [Fact]
        public async Task GetLeaveTypelist_GetAllLeaveTypes()
        {
            var handler = new GetLeaveTypesQueryHandler(_mapper,_mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new  GetLeaveTypesQuery(), CancellationToken.None);

            result.ShouldNotBeEmpty();
            result.ShouldBeOfType<List<LeaveTypeDto>>();
            result.Count.ShouldBe(3);
        }
    }
}
