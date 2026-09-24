namespace Gateway.Domain;

public class Transaction
{
    public Guid Id { get; set; }
    public TransactionType Type { get; set; }
    public TransactionStatus Status { get; set; }
    public Money Amount { get; set; } = null!;
    public Money CapturedAmount { get; set; } = null!;
    public Money RefundedAmount { get; set; } = null!;
    public Guid? ParentTransactionId { get; set; }
    public Guid PaymentTokenId { get; set; }
    public string? AuthCode { get; set; }
    public string? NetworkReference { get; set; }
    public string? ResponseCode { get; set; }
    public Guid? BatchId { get; set; }
    public string? IdempotencyKey { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public byte[] RowVersion { get; set; } = null!;

    private Transaction() { }

    public static Transaction CreateAuthorization(
        Money amount,
        Guid paymentTokenId,
        string? idempotencyKey
    )
    {
        return new()
        {
            Id = Guid.NewGuid(),
            Type = TransactionType.Authorization,
            Status = TransactionStatus.Created,
            Amount = amount,
            CapturedAmount = new Money(0, amount.Currency),
            RefundedAmount = new Money(0, amount.Currency),
            IdempotencyKey = idempotencyKey,
            PaymentTokenId = paymentTokenId,
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedAt = DateTimeOffset.UtcNow,
        };
    }
}
