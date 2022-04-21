using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class InventoryItems : MonoBehaviour
{
    [SerializeField] private ItemData _startingItemData;
    [SerializeField] private List<ItemData> _itemData;
    [SerializeField] private AssetReference _purchasedItemCellReference;
    [SerializeField] private Transform _purchasedItemCellParent;
    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private FileNames.SelectedItems _selectedItemFileName;
    private List<PurchasedItemCell> _purchasedItemCells = new List<PurchasedItemCell>();
    private PurchasedItemCell _selectedPurchasedItemCell;

    private void Start() => SetInitialSettings();

    private void SetInitialSettings()
    {
        SelectedItem selectedItem = _saveSystem.Object<SelectedItem>(_selectedItemFileName.ToString());
        if (selectedItem.AssetReference.AssetGUID != "") return;
        SelectedItem startingSelectedItem = new SelectedItem(_startingItemData.AssetReference);
        _saveSystem.Save(_selectedItemFileName.ToString(), startingSelectedItem);
    }

    public void Open()
    {
        CreateItemCell(_startingItemData);
        foreach (ItemData itemData in _itemData)
        {
            PaymentStatus paymentStatus = _saveSystem.Object<PaymentStatus>(itemData.Name);
            if (paymentStatus.Paid) CreateItemCell(itemData);
        }
    }

    private void CreateItemCell(ItemData itemData)
    {
        SelectedItem selectedItem = _saveSystem.Object<SelectedItem>(_selectedItemFileName.ToString());
        bool itemSelected = selectedItem.AssetReference.AssetGUID == itemData.AssetReference.AssetGUID ? true : false;
        PurchasedItemCell itemCell = LocalAssetLoader.LoadAsset<PurchasedItemCell>(_purchasedItemCellReference, _purchasedItemCellParent);
        itemCell.Init(itemData, itemSelected);
        itemCell.OnSelect += SelectItemCell;
        _purchasedItemCells.Add(itemCell);
        if (itemSelected) _selectedPurchasedItemCell = itemCell;
    }
    
    private void SelectItemCell(ItemData itemData)
    {
        if (_selectedPurchasedItemCell) _selectedPurchasedItemCell.Deselect();
        SelectedItem selectedItem = new SelectedItem(itemData.AssetReference);
        _saveSystem.Save(_selectedItemFileName.ToString(), selectedItem);
        foreach (PurchasedItemCell itemCell in _purchasedItemCells)
        {
            if (itemCell.ItemData != itemData) continue;
            _selectedPurchasedItemCell = itemCell;
            return;
        }
    }

    public void Close()
    {
        foreach (PurchasedItemCell itemCell in _purchasedItemCells)
        {
            itemCell.OnSelect -= SelectItemCell;
            itemCell.Destroy();
        }
        _purchasedItemCells.Clear();
    }

    private void OnDestroy() => Close();
}
