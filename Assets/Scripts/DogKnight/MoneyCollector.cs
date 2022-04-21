using TMPro;
using UnityEngine;

public class MoneyCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _crystalText;
    [SerializeField] private SaveSystem _saveSystem;
    private int _coins;
    private int _crystals;
    
    public void Collect(Money money)
    {
        if (money is Coin)
        {
            _coins++;
            _coinText.text = _coins.ToString();
        }
        else
        {
            _crystals++;
            _crystalText.text = _crystals.ToString();
        }
    }

    public void BankTransfer()
    {
        Deposit(FileNames.MoneyVaults.Coins, _coins);
        Deposit(FileNames.MoneyVaults.Crystals, _crystals);
    }

    public void Deposit(FileNames.MoneyVaults vault, int value)
    {
        MoneyVaults moneyVaults = _saveSystem.Object<MoneyVaults>(vault.ToString());
        int money = value + moneyVaults.Money;
        MoneyVaults newMoneyVaults = new MoneyVaults(money);
        _saveSystem.Save(vault.ToString(), newMoneyVaults);
    }
}
