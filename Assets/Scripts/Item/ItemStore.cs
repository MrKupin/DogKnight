using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

public class ItemStore : MonoBehaviour
{
    [SerializeField] private List<ItemData> _itemData;
    [SerializeField] private AssetReference _sellableItemCellReference;
    [SerializeField] private Transform _sellableItemCellParent;
    [SerializeField] private PaymentSystem _paymentSystem;
    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private Text _errorText;
    private List<SellableItemCell> _sellableItemCells = new List<SellableItemCell>();

    private void Awake() => _errorText.enabled = false;

    public void Open()
    {
        _paymentSystem.OnPay += WriteOffItem;
        foreach (ItemData itemData in _itemData)
        {
            PaymentStatus paymentStatus = _saveSystem.Object<PaymentStatus>(itemData.Name);
            if (paymentStatus.Paid) continue;
            CreateItemCell(itemData);
        }
        if (_sellableItemCells.Count == 0) _errorText.enabled = true;
    }

    private void CreateItemCell(ItemData itemData)
    {
        SellableItemCell itemCell = LocalAssetLoader.LoadAsset<SellableItemCell>(_sellableItemCellReference, _sellableItemCellParent);
        _sellableItemCells.Add(itemCell);
        itemCell.Init(itemData);
        itemCell.OnSelect += _paymentSystem.TryPay;
    }
    
    private void WriteOffItem(ItemData itemData)
    {
        foreach (SellableItemCell itemCell in _sellableItemCells)
        {
            if (itemCell.ItemData == itemData)
            {
                itemCell.OnSelect -= _paymentSystem.TryPay;
                itemCell.Destroy();
                _sellableItemCells.Remove(itemCell);
                return;
            }
        }
    }

    public void Close()
    {
        foreach (SellableItemCell itemCell in _sellableItemCells)
        {
            itemCell.OnSelect -= _paymentSystem.TryPay;
            itemCell.Destroy();
        }
        _sellableItemCells.Clear();
        _paymentSystem.OnPay -= WriteOffItem;
    }

    private void OnDestroy() => Close();
}
