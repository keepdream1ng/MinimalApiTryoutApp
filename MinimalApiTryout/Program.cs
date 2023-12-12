var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<ClassLibraryEntryPoint>());
builder.Services.AddTransient(typeof(IPipelineBehavior<NewIpInfoRequest, string>), typeof(NewIpInfoPipelineBehavior));
builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.MapGet("/api/{ip}", async (IMediator mediator, string ip) =>
	await mediator.Send(new NewIpInfoRequest(ip)));

app.Run();
