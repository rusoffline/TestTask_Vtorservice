using System;
using System.Net;
using System.Text;
using System.Xml;

class Program
{
    static void Main(string[] args)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

        Console.Write("Введите код валюты (например, USD, EUR): ");
        string currencyCode = Console.ReadLine().ToUpper();

        string url = "https://www.cbr.ru/scripts/XML_daily.asp";

        try
        {
            using (WebClient client = new WebClient())
            {
                client.Encoding = Encoding.GetEncoding("windows-1251");
                string response = client.DownloadString(url);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(response);

                XmlNode currency = null;
                foreach (XmlNode node in xmlDoc.GetElementsByTagName("Valute"))
                {
                    XmlNode charCodeNode = node.SelectSingleNode("CharCode");
                    if (charCodeNode != null && charCodeNode.InnerText == currencyCode)
                    {
                        currency = node;
                        break;
                    }
                }

                if (currency != null)
                {
                    string name = currency.SelectSingleNode("Name")?.InnerText;
                    string value = currency.SelectSingleNode("Value")?.InnerText;
                    string nominal = currency.SelectSingleNode("Nominal")?.InnerText;

                    Console.WriteLine($"{name} ({currencyCode}) - {value} за {nominal} единиц.");
                }
                else
                {
                    Console.WriteLine("Не найдено данных для указанной валюты.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
