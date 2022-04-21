using System;
using UnityEngine;
using UnityEngine.AddressableAssets;

[Serializable]
public class SelectedItem
{
    [SerializeField] private AssetReference _assetReference;
    public AssetReference AssetReference => _assetReference;

    public SelectedItem()
    {
        _assetReference = new AssetReference();
    }

    public SelectedItem(AssetReference assetReference) => _assetReference = assetReference;
}