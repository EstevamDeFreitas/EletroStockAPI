namespace EletroStockAPI.Utilities.Messages
{
    public class MessageBase<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }
    }

    public static class Message
    {
        public const string Success = "Success";
        public const string NotFound = "Object Not Found";
        public const string Error = "An unexpected error occurred";
        public const string ObjectInUse = "Object in Use";
    }

    public static class AddressMessage
    {
        public const string ChargeNotFound = "Charge Address Not Found";
        public const string DeliveryNotFound = "Delivery Address Not Found";
    }

    public static class UserMessage
    {
        public const string EmailAlreadyInUse = "Email Alredy in Use";
    }
}
