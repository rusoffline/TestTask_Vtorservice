public class CurrencyInfo
{
    public string Code { get; }
    public string Name { get; }
    public string Value { get; }

    public CurrencyInfo(string code, string name, string value)
    {
        Code = code;
        Name = name;
        Value = value;
    }
}
