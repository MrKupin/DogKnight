using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.VFX;

public class Slime : MonoBehaviour, IDeath
{
    [SerializeField] private SphereCollider _sphereCollider;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _cuttingMeatSound;

    public void Kill()
    {
        _cuttingMeatSound.Play();
        _animator.SetTrigger("Die");
        _sphereCollider.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint point = collision.contacts[0];
        if (point.normal.y != 0)
            return;
        if (collision.gameObject.TryGetComponent(out IHealth health))
            health.TakeDamage();
    }
}
