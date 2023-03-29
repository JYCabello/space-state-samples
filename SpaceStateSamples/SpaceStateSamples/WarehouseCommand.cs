namespace SpaceStateSamples;

public class Natural
{
    public int Value { get; }

    public Natural(int value)
    {
        if (value < 1)
            throw new ArgumentException("The value needs to be a non-zero positive integer");
        Value = value;
    }
}

public record StockReceived(Guid ProductID, Natural Amount);

public record StockReserved(Guid ProductID, Natural Amount, Guid OrderID);

public record StockReservationExpired(Guid ProductID, Natural Amount, Guid OrderID);

public record StockShrunk(Guid ProductID, Natural Amount, Guid ReportingUserID);

public record StockOrdered(Guid ProductID, Natural Amount, Guid OrderID);

public record StockOrderCancelled(Guid ProductID, Natural Amount);

public record Stock(Guid ProductID, int Amount)
{
    public Stock Reduce(StockReceived received) =>
        this with { Amount = Amount + received.Amount.Value };

    public Stock Reduce(StockReserved reserved) =>
        this with { Amount = Amount - reserved.Amount.Value };

    public Stock Reduce(StockReservationExpired reservationExpired) =>
        this with { Amount = Amount + reservationExpired.Amount.Value };

    public Stock Reduce(StockShrunk shrunk) =>
        this with { Amount = Amount - shrunk.Amount.Value };

    public Stock Reduce(StockOrdered ordered) => this;

    public Stock Reduce(StockOrderCancelled orderCancelled) =>
        this with { Amount = Amount + orderCancelled.Amount.Value };
};
