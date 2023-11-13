using Microsoft.AspNetCore.Mvc.Testing;
using MyTest.Api;
using MyTest.Api.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

public class TestRegion1
{

    // Scénario 1

    // Récupérer les régions d’un pays existant

    [Fact]
    public async Task TestRegion()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();

        var response = await client.GetAsync("Region/France");
        string stringResponse = await response.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var regions = JsonSerializer.Deserialize<List<RegionModel>>(stringResponse, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true 
        });

        Assert.NotNull(regions);
        Assert.NotEmpty(regions);
        Assert.Equal("Nouvelle-Aquitaine", regions[0].Name);
    }

    // Scénario 2

    // Récupérer les régions d’un pays mais le pays est inexistant

    [Fact]
     public async Task TestRegionPaysNonExistant()
    {
        await using var _factory = new WebApplicationFactory<Program>();
        var client = _factory.CreateClient();

        var response = await client.GetAsync("Region/kfjvfdbi");

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}
