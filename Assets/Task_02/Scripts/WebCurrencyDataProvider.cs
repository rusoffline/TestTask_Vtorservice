using System.Net;
using System.Text;

public class WebCurrencyDataProvider : ICurrencyDataProvider
{
    private const string ApiUrl = "https://www.cbr.ru/scripts/XML_daily.asp";

    public string GetCurrencyData()
    {
        using (WebClient client = new WebClient())
        {
            client.Encoding = Encoding.GetEncoding("windows-1251");
            return client.DownloadString(ApiUrl);
        }
    }
}
