using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.VFX;

public class CoinBox : MonoBehaviour, IDeath, ITrampoline
{
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private AudioSource _boxBreakingSound;
    [SerializeField] private AssetReference _coinBoxBreakEffectReference;
    [SerializeField] private AssetReference _coinReference;
    [SerializeField] private Transform _coinStartPoint;
    private VisualEffect _coinBoxBreakEffect;

    private void Start() => CreateEffect();

    private async void CreateEffect()
    {
        _coinBoxBreakEffect = await LocalAssetLoader.LoadAssetAsync<VisualEffect>(_coinBoxBreakEffectReference);
        _coinBoxBreakEffect.transform.position = transform.position;
    }

    public async void Kill()
    {
        _boxBreakingSound.Play();
        _coinBoxBreakEffect.Play();
        Coin coin = await LocalAssetLoader.LoadAssetAsync<Coin>(_coinReference);
        coin.transform.position = _coinStartPoint.position;
        _boxCollider.enabled = false;
        _meshRenderer.enabled = false;
    }

    public void Push(IMovement movement) => movement.Jump();
}
