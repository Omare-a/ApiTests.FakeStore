using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.FakeStore;

public class ProductsApiTests
{
    [Fact]
    [Trait("Category", "ApiIntegration")]
    public async Task Get_Products_Returns_200_OK()
    {
        using var http = new HttpClient
        {
            BaseAddress = new Uri("https://fakestoreapi.com/"),
            Timeout = TimeSpan.FromSeconds(20)
        };

        //CI: vissa tjänster blockerar “tomma” requests utan ua
        http.DefaultRequestHeaders.UserAgent.Clear();
        http.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("Mozilla", "5.0"));
        http.DefaultRequestHeaders.Accept.Clear();
        http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        using var request = new HttpRequestMessage(HttpMethod.Get, "products");
        request.Headers.CacheControl = new CacheControlHeaderValue { NoCache = true };

        using var response = await http.SendAsync(request);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
