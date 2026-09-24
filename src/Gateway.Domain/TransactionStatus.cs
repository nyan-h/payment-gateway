namespace Gateway.Domain;

public enum TransactionStatus
{
    Created = 0,
    Approved = 1,
    Declined = 2,
    Failed = 3,
    Captured = 4,
    PartiallyCaptured = 5,
    Voided = 6,
    Expired = 7,
    Batched = 8,
    Settled = 9,
    SettlementRejected = 10
}