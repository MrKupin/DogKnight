using System;
using UnityEngine;
using TMPro;

public class Bank : MonoBehaviour
{
    public event Action OnWithdraw;
    public event Action OnWithdrawError;
    [SerializeField] private TextMeshProUGUI _balance;
    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private FileNames.MoneyVaults _moneyVaultsFileName;
    private MoneyVaults _moneyVaults;

    private void Start() => ShowBalance();

    public void WithdrawMoney(int value)
    {
        if (_moneyVaults.Money < value)
        {
            OnWithdrawError?.Invoke();
            return;
        }
        int money = _moneyVaults.Money - value;
        _moneyVaults = new MoneyVaults(money);
        _saveSystem.Save(_moneyVaultsFileName.ToString(), _moneyVaults);
        ShowBalance();
        OnWithdraw?.Invoke();
    }

    private void ShowBalance()
    {
        _moneyVaults = _saveSystem.Object<MoneyVaults>(_moneyVaultsFileName.ToString());
        _balance.text = _moneyVaults.Money.ToString();
    }
}
