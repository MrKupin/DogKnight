using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.VFX;

public class CrystalBox : MonoBehaviour, IDeath, ITrampoline
{
    [SerializeField] private BoxCollider _boxCollider;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private AudioSource _boxBreakingSound;
    [SerializeField] private AssetReference _crystalBoxBreakEffectReference;
    [SerializeField] private AssetReference _crystalReference;
    [SerializeField] private Transform _crystalStartPoint;
    private VisualEffect _crystalBoxBreakEffect;

    private void Start() => CreateEffect();

    private async void CreateEffect()
    {
        _crystalBoxBreakEffect = await LocalAssetCreator.CreateAssetAsync<VisualEffect>(_crystalBoxBreakEffectReference);
        _crystalBoxBreakEffect.transform.position = transform.position;
    }

    public async void Kill()
    {
        _boxBreakingSound.Play();
        _crystalBoxBreakEffect.Play();
        Crystal crystal = await LocalAssetCreator.CreateAssetAsync<Crystal>(_crystalReference);
        crystal.transform.position = _crystalStartPoint.position;
        _boxCollider.enabled = false;
        _meshRenderer.enabled = false;
    }

    public void Push(IMovement movement) => movement.Jump();
}
