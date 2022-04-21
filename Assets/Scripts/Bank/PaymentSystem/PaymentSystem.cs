using System;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class PaymentSystem : MonoBehaviour
{
    public event Action<ItemData> OnPay;
    [SerializeField] private PopUpError _paymentError;
    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private Bank _bank;
    private ItemData _itemData;

    private void Start()
    {
        _bank.OnWithdraw += Pay;
        _bank.OnWithdrawError += ShowError;
    }

    public void TryPay(ItemData itemData)
    {
        _itemData = itemData;
        _bank.WithdrawMoney(itemData.Price);
    }

    private void Pay()
    {
        PaymentStatus paymentStatus = new PaymentStatus(true);
        _saveSystem.Save(_itemData.Name, paymentStatus);
        OnPay?.Invoke(_itemData);
    }

    private void ShowError()
    {
        _paymentError.PopUp();
    }

    private void OnDestroy()
    {
        _bank.OnWithdraw -= Pay;
        _bank.OnWithdrawError -= ShowError;
    }
}
