public interface ICurrencyParser
{
    CurrencyInfo ParseCurrency(string xmlData, string currencyCode);
}
