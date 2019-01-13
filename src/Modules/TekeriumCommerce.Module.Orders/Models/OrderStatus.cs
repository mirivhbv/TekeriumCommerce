namespace TekeriumCommerce.Module.Orders.Models
{
    public enum OrderStatus
    {
        New = 1,

        OnHold = 10,

        PendingPayment = 20,

        Invoiced = 40, // search what it is means

        Complete = 70,

        Canceled = 80,

        Closed = 100
    }
}