namespace Gateway.Domain;

public class PaymentToken
{
    public Guid Id { get; set; }
    public CardBrand Brand { get; set; }
    public required string Bin { get; set; }
    public required string Last4 { get; set; }
    public int ExpMonth { get; set; }
    public int ExpYear { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}