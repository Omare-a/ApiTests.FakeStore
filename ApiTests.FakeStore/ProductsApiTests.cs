using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApiTests.FakeStore;

public class ProductsApiTests
{
    private static readonly HttpClient _http = new()
    {
        BaseAddress = new Uri("https://fakestoreapi.com/"),
        Timeout = TimeSpan.FromSeconds(15)
    };

    [Fact]
    public async Task Get_Products_Returns_200_OK()
    {
        // Act
        using var response = await _http.GetAsync("products");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
