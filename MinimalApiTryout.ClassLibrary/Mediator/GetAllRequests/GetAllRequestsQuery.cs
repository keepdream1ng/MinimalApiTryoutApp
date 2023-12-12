using MediatR;
using MinimalApiTryout.ClassLibrary.Models;

namespace MinimalApiTryout.ClassLibrary.Mediator;
public record GetAllRequestsQuery() : IRequest<List<IpRequest>>;
