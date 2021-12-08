namespace XO.SystemExtensions.Exceptions
{
    public class UnhandledEnumValueException : Exception
    {
        public UnhandledEnumValueException(Enum value)
            => UnhandledValue = value;

        public override string Message
            => $"Value \"{UnhandledValue}\" of enum \"{EnumTypeName}\" is not handled.";

        public string EnumTypeName
            => UnhandledValue.GetType().Name;

        public Enum UnhandledValue { get; }
    }
}
