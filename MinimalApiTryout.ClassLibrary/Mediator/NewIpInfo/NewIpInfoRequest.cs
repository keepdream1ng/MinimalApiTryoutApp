using MediatR;

namespace MinimalApiTryout.ClassLibrary.Mediator;
public record NewIpInfoRequest(string Ip) : IRequest<string>;
