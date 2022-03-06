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

        public const string ObjectInUse = "Object in Use";
    }
}
