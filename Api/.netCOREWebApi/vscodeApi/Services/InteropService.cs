using Clients.CleanArchitectureClient;
using vscodeApi.Interfaces;
using vscodeApi.Models;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace vscodeApi.Services;

public class InteropService : IInteropService
{
    private readonly ILogger<InteropService> _logger;
    private readonly AppSettings _appSettings;

    public InteropService(ILogger<InteropService> logger, IOptions<AppSettings> appSettings)
    {
        _logger = logger;
        _appSettings = appSettings.Value;
        ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, error) => true;
    }
    // Add methods for interop functionality here

    // private static bool ValidateCertificate(object sender, X509Certificate? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
    // {
    //     // Implement your certificate validation logic here
    //     return true;
    // }

    public async Task<IEnumerable<Blog>> GetAllBlogs()
    {
        try
        {
            var handler = new HttpClientHandler();
            handler.ClientCertificateOptions = ClientCertificateOption.Manual;
            handler.ServerCertificateCustomValidationCallback = 
            (httpRequestMessage, cert, cetChain, policyErrors) =>
            {
                return true;
            };
            var httpClient = new HttpClient(handler);
            httpClient.BaseAddress = new Uri(_appSettings.CleanArchitectureBaseUrl);
      
            var c = new Client(_appSettings.CleanArchitectureBaseUrl,httpClient);
            IEnumerable<Blog> blogs = await c.BlogAllAsync();
            return blogs;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching blogs");
            throw;
        }
    }
}

