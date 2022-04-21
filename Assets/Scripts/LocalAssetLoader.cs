using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class LocalAssetLoader
{
    public static T LoadAsset<T>(AssetReference assetReference, Transform parent = null)
    {
        var handle = Addressables.InstantiateAsync(assetReference, parent);
        handle.WaitForCompletion();
        if (handle.Result.TryGetComponent(out T type))
            return type;
        throw new System.NullReferenceException();
    }
    
    public static async Task<T> LoadAssetAsync<T>(AssetReference assetReference, Transform parent = null)
    {
        var handle = Addressables.InstantiateAsync(assetReference, parent);
        var asset = await handle.Task;
        if (asset.TryGetComponent(out T type))
            return type;
        throw new System.NullReferenceException();
    }
}
