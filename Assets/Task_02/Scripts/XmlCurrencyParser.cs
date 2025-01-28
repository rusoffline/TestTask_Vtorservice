using System.Xml;

public class XmlCurrencyParser : ICurrencyParser
{
    public CurrencyInfo ParseCurrency(string xmlData, string currencyCode)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(xmlData);
        currencyCode = currencyCode.ToUpper();

        XmlNode node = xmlDoc.SelectSingleNode($"//Valute[CharCode='{currencyCode}']");
        if (node != null)
        {
            string value = node.SelectSingleNode("Value").InnerText;
            string name = node.SelectSingleNode("Name").InnerText;
            return new CurrencyInfo(currencyCode, name, value);
        }
        return null;
    }
}
