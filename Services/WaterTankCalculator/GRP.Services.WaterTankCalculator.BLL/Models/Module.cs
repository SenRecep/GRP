public record Module
{
    public string? Name { get; set; }
    public float Weight { get; set; }
    public string? Dimensions { get; set; }
    public string? Type { get; set; }
    public int TotalOrders { get; set; }
    public float TotalWeight { get; set; }
    public float Cost { get; set; }
}

