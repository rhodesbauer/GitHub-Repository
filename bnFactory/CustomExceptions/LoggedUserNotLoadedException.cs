namespace Factory.Exceptions
{
    public class LoggedUserNotLoadedException : System.Exception
    {
        public LoggedUserNotLoadedException() { }
        public LoggedUserNotLoadedException(string message) : base(message) { }
        public LoggedUserNotLoadedException(string message, System.Exception inner) : base(message, inner) { }
        protected LoggedUserNotLoadedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}