using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.VFX;

public class RewardBox : MonoBehaviour, IDeath, ITrampoline
{
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private AudioSource _boxBreakingSound;
    [SerializeField] private AssetReference _boxBreakEffectReference;
    [SerializeField] private AssetReference _rewardReference;
    [SerializeField] private Transform _rewardStartPoint;
    private VisualEffect _rewardBoxBreakEffect;

    private void Start() => CreateEffect();

    private async void CreateEffect()
    {
        _rewardBoxBreakEffect = await LocalAssetLoader.LoadAssetAsync<VisualEffect>(_boxBreakEffectReference);
        _rewardBoxBreakEffect.transform.position = transform.position;
    }

    public async void Kill()
    {
        _boxBreakingSound.Play();
        _rewardBoxBreakEffect.Play();
        Money money = await LocalAssetLoader.LoadAssetAsync<Money>(_rewardReference);
        money.transform.position = _rewardStartPoint.position;
        _boxCollider.enabled = false;
        _meshRenderer.enabled = false;
    }

    public void Push(IMovement movement) => movement.Jump();
}
