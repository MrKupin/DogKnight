using System;
using UnityEngine;
using UnityEngine.UI;

public class PurchasedItemCell : MonoBehaviour
{
    public Action<ItemData> OnSelect;
    [SerializeField] private Image _previewImage;
    [SerializeField] private Button _selectButton;
    private ItemData _itemData;
    public ItemData ItemData => _itemData;

    private void Awake() => _selectButton.gameObject.SetActive(true);

    public void Init(ItemData itemData, bool itemSelected)
    {
        _itemData = itemData;
        _previewImage.sprite = itemData.Icon;
        if (itemSelected) _selectButton.gameObject.SetActive(false);
    }

    public void Select()
    {
        _selectButton.gameObject.SetActive(false);
        OnSelect?.Invoke(_itemData);
    }

    public void Deselect() => _selectButton.gameObject.SetActive(true);

    public void Destroy() => Destroy(gameObject);
}
