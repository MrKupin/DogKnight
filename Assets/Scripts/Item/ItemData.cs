using UnityEngine;
using UnityEngine.AddressableAssets;

public abstract class ItemData : ScriptableObject
{
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public int Price { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public AssetReference AssetReference { get; private set; }
}
