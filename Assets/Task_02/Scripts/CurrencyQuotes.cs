using UnityEngine;

public class CurrencyQuotes : MonoBehaviour
{
    [Tooltip("USD, EUR, GBP, JPY, CNY, CHF, AUD")]
    [SerializeField] private string currencyCode = "USD";

    private ICurrencyQuoteService currencyQuoteService;

    private void Start()
    {
        PrintCurrencyQuote();
    }

    [ContextMenu("Вывести котировку")]
    private void PrintCurrencyQuote()
    {
        if (currencyQuoteService == null)
        {
            ICurrencyDataProvider dataProvider = new WebCurrencyDataProvider();
            ICurrencyParser parser = new XmlCurrencyParser();
            currencyQuoteService = new CurrencyQuoteService(dataProvider, parser);
        }

        CurrencyInfo info = currencyQuoteService.GetCurrencyQuote(currencyCode);

        if (info != null)
        {
            Debug.Log($"Котировка {info.Name} ({info.Code}): {info.Value} руб.");
        }
        else
        {
            Debug.LogError($"Валюта с кодом {currencyCode} не найдена.");
        }
    }
}