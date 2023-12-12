using MediatR;

namespace MinimalApiTryout.ClassLibrary.Mediator;
public class NewIpInfoPipelineBehavior : IPipelineBehavior<NewIpInfoRequest, string>
{
	public Task<string> Handle(NewIpInfoRequest request, RequestHandlerDelegate<string> next, CancellationToken cancellationToken)
	{
		Console.WriteLine(request.Ip);
		return next();
	}
}
