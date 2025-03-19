using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Tabsil.Sijil;


public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;

    [field: SerializeField] public int Currency { get; private set; }

    [Header(" Actions ")]
    public static Action onUpdated;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        //AddPremiumCurrency(PlayerPrefs.GetInt(premiumCurrencyKey, 100), false);

        //Candy.onCollected += CandyCollectedCallback;
        //Cash.onCollected += CashCollectedCallback;
    }
    void Start()
    {
        UpdateTexts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [NaughtyAttributes.Button]
    private void Add500Currency() => AddCurrency(500);
    public void AddCurrency(int amount)
    {
        Currency += amount;
        UpdateTexts();

        onUpdated?.Invoke();
        //UpdateVisuals();
    }
    private void UpdateTexts()
    {
        CurrencyText[] currencyTexts = FindObjectsByType<CurrencyText>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (CurrencyText text in currencyTexts)
            text.UpdateText(Currency.ToString());

        //PremiumCurrencyText[] premiumCurrencyTexts = FindObjectsByType<PremiumCurrencyText>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        //foreach (PremiumCurrencyText text in premiumCurrencyTexts)
        //    text.UpdateText(PremiumCurrency.ToString());
    }
    public void UseCurrency(int price) => AddCurrency(-price);
    public bool HasEnoughCurrency(int price) => Currency >= price;
}
