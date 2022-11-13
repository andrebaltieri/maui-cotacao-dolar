using System;
using System.Threading;
using System.Text.Json.Serialization;
using RestSharp;

namespace CotacaoDolar.Models;

public class ExchangeRateService
{
    public async Task<ExchangeRate?> GetAsync()
    {
        var url = $"https://olinda.bcb.gov.br/olinda/servico/PTAX/versao/v1/odata/CotacaoDolarDia(dataCotacao=@dataCotacao)?@dataCotacao='{DateTime.Now.ToString("MM-dd-yyyy")}'&$top=100&$format=json";
        var client = new RestClient(url);
        var request = new RestRequest();
        try
        {
            var response = await client.GetAsync<ExchangeRate>(request, new CancellationToken());
            return response;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
}

public class ExchangeRate
{
    [JsonPropertyName("@odata.context")]
    public string Context { get; set; }

    [JsonPropertyName("value")]
    public List<Value> Value { get; set; }
}

public class Value
{
    [JsonPropertyName("cotacaoCompra")]
    public double Buy { get; set; }

    [JsonPropertyName("cotacaoVenda")]
    public double Sell { get; set; }
}