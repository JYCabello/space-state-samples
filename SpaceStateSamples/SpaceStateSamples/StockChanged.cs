namespace SpaceStateSamples;

public record StockChanged(
    Guid ProductID,
    int Amount,
    StockChangeReason Reason,
    Guid? PurchaseID,
    Guid? CustomerID,
    Guid? ReportingUserID,
    Guid? OrderID);

public enum StockChangeReason
{
    Received,
    Reserved,
    ReserveExpired,
    Shrinkage,
    Ordered,
    OrderCancelled
}
