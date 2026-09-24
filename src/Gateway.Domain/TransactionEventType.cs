namespace Gateway.Domain;

public enum TransactionEventType
{
    Unknown = 0,
    Authorized = 1,
    AuthorizationDeclined = 2,
    AuthorizationFailed = 3
}