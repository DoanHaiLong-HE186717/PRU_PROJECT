using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager instance;

    [field: SerializeField] public int Currency { get; private set; }
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateTexts();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCurrency(int amount)
    {
        Currency += amount;
        UpdateTexts();
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
}
