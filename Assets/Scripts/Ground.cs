using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.VFX;

public class Ground : MonoBehaviour, IDust
{
    [SerializeField] private AudioSource _fallToGroundSound;
    [SerializeField] private AssetReference _groundContactEffectReference;
    private VisualEffect _groundContactEffect;

    private void Start()
    {
        _groundContactEffect = LocalAssetLoader.LoadAsset<VisualEffect>(_groundContactEffectReference);
    }

    public void MakeDusty(Vector3 position)
    {
        _fallToGroundSound.Play();
        _groundContactEffect.transform.position = position;
        _groundContactEffect.Play();
    }
}
