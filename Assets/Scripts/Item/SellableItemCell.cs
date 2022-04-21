using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellableItemCell : MonoBehaviour
{
    public event Action<ItemData> OnSelect;
    [SerializeField] private TextMeshProUGUI _priceText;
    [SerializeField] private Image _previewImage;
    [SerializeField] private Button _selectButton;
    private ItemData _itemData;
    public ItemData ItemData => _itemData;

    private void Start() => _selectButton.gameObject.SetActive(true);

    public void Init(ItemData itemData)
    {
        _itemData = itemData;
        _priceText.text = itemData.Price.ToString();
        _previewImage.sprite = itemData.Icon;
    }

    public void Select() => OnSelect?.Invoke(_itemData);

    public void Destroy() => Destroy(gameObject);
}
