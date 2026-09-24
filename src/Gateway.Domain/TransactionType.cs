namespace Gateway.Domain;

public enum TransactionType
{
    Sale = 0,
    Authorization = 1,
    Capture = 2,
    Refund = 3,
    Void = 4,
}
