using MediatR;
using Microsoft.Extensions.Configuration;
using System.Net.Http;

namespace MinimalApiTryout.ClassLibrary.Mediator;
public class NewIpInfoRequestHandler : IRequestHandler<NewIpInfoRequest, string>
{
	private readonly IConfiguration _configuration;
	private readonly IHttpClientFactory _httpClientFactory;

	public NewIpInfoRequestHandler(
		IConfiguration configuration,
		IHttpClientFactory httpClientFactory)
	{
		_configuration = configuration;
		_httpClientFactory = httpClientFactory;
	}
	public async Task<string> Handle(NewIpInfoRequest request, CancellationToken cancellationToken)
	{
		string url = _configuration["IpInfoProvider"].Replace("{RequestIp}", request.Ip);
		using var httpClient = _httpClientFactory.CreateClient();
		return await httpClient.GetStringAsync(url);
	}
}
