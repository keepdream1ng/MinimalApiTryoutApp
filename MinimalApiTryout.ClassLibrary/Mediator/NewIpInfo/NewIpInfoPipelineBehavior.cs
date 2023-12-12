using MediatR;
using MinimalApiTryout.ClassLibrary.Models;

namespace MinimalApiTryout.ClassLibrary.Mediator;
public class NewIpInfoPipelineBehavior : IPipelineBehavior<NewIpInfoRequest, string>
{
	private readonly AppDbContext _dbContext;

	public NewIpInfoPipelineBehavior(AppDbContext dbContext)
    {
		_dbContext = dbContext;
	}
    public Task<string> Handle(NewIpInfoRequest request, RequestHandlerDelegate<string> next, CancellationToken cancellationToken)
	{
		// Saving unique requests to database. I think this could be used to do cashing instead of just logging.
		if (!_dbContext.IpRequests.Any(req => req.Ip == request.Ip))
		{
			_dbContext.AddAsync(new IpRequest { Ip = request.Ip });
			_dbContext.SaveChangesAsync();
		}
		return next();
	}
}
