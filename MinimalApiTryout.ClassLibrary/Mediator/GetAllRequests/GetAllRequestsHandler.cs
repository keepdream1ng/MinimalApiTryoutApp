using MediatR;
using MinimalApiTryout.ClassLibrary.Models;

namespace MinimalApiTryout.ClassLibrary.Mediator;
public class GetAllRequestsHandler : IRequestHandler<GetAllRequestsQuery, List<IpRequest>>
{
	private readonly AppDbContext _dbContext;

	public GetAllRequestsHandler(AppDbContext dbContext)
    {
		_dbContext = dbContext;
	}
    public Task<List<IpRequest>> Handle(GetAllRequestsQuery request, CancellationToken cancellationToken)
	{
		return Task.FromResult(_dbContext.IpRequests.ToList());
	}
}
