using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class HeartsView : MonoBehaviour
{
    [SerializeField] private AssetReferenceGameObject _heartImageReference;
    private List<Image> _heartsImages = new List<Image>();

    public void CreateHearts(int numberHearts)
    {
        for (int i = 0; i < numberHearts; i++)
        {
            Image image = LocalAssetLoader.LoadAsset<Image>(_heartImageReference, transform);
            _heartsImages.Add(image);
        }
    }

    public void RemoveHeart()
    {
        if (_heartsImages.Count == 0)
            return;

        int indexLastHeart = _heartsImages.Count - 1;
        Destroy(_heartsImages[indexLastHeart].gameObject);
        _heartsImages.RemoveAt(indexLastHeart);
    }
}
