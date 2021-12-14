#nullable disable
using System.Text.Json.Serialization;

namespace GRP.Services.WaterTankCalculator.BLL.Models;

public class Exchange
{
    [JsonPropertyName("timestamp")]
    public int Timestamp { get; set; }
    [JsonPropertyName("rates")]
    public Rates Rates { get; set; }
}

public class Rates
{
    public float TRY { get; set; }
}