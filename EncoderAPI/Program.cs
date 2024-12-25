using EncoderAPI.Encryption;
using EncoderAPI.Messages;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddTransient<IEncoder, MD5Encoder>();
//builder.Services.AddTransient<IEncoder, BCryptEncoder>();
//builder.Services.AddTransient<IEncoder, AesEncoder>();
builder.Services.AddTransient(opts => EncoderFactory.CreateEncoderFactory());

var app = builder.Build();

app.MapGet("/", () => new ServerMessge { Message = "server is running"});

app.MapGet("/ping", () => new StringMessage() { Message = "pong" });

app.MapPost("/crypt/sugar", (StringData data, IEncoder encoder) =>
{
    if (String.IsNullOrEmpty(data.Data))
    {
        return new StringMessage { Message = "DataError" };
    }
    return new StringMessage { Message = $"{encoder.AlgoritmName}: {encoder.Encode(data.Data)}" };
});

app.MapPost("/crypt/context", async (context) =>
{
    try
    {
        var data = context.Request.ReadFromJsonAsync<StringData>();
        IEncoder encoder = context.RequestServices.GetRequiredService<IEncoder>();
        if (String.IsNullOrEmpty(data.Result.Data))
        {
            await context.Response.WriteAsJsonAsync(new StringMessage { Message = "DataError" });
        }
        await context.Response.WriteAsJsonAsync(new StringMessage { Message = $"{encoder.AlgoritmName}: {encoder.Encode(data.Result.Data)}" });
    }
    catch (Exception ex)
    {
        await context.Response.WriteAsync($"some error: {ex.Message}");
    }
});
app.Run();
