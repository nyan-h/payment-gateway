namespace Gateway.Domain;

public class TransactionEvent
{
    public Guid Id { get; set; }
    public Guid TransactionId { get; set; }
    public TransactionEventType EventType { get; set; }
    public TransactionStatus? FromStatus { get; set; }
    public TransactionStatus? ToStatus { get; set; }
    public string? PayloadJson { get; set; }
    public DateTimeOffset OccurredAt { get; set; }
    public Guid? CorrelationId { get; set; }
}