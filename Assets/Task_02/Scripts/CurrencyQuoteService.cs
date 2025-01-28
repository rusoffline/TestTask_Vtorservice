using System;
using UnityEngine;

public class CurrencyQuoteService : ICurrencyQuoteService
{
    private readonly ICurrencyDataProvider dataProvider;
    private readonly ICurrencyParser parser;

    public CurrencyQuoteService(ICurrencyDataProvider dataProvider, ICurrencyParser parser)
    {
        this.dataProvider = dataProvider;
        this.parser = parser;
    }

    public CurrencyInfo GetCurrencyQuote(string currencyCode)
    {
        try
        {
            string xmlData = dataProvider.GetCurrencyData();
            return parser.ParseCurrency(xmlData, currencyCode);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Ошибка при получении данных: {ex.Message}");
            return null;
        }
    }
}

