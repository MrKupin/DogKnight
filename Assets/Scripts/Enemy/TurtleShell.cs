using UnityEngine;

public class TurtleShell : MonoBehaviour, IArmor
{
    [SerializeField] private SphereCollider _sphereCollider;
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _cuttingMeatSound;

    public void Destroy()
    {
        _cuttingMeatSound.Play();
        _animator.SetTrigger("Die");
        _sphereCollider.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IHealth health))
            health.TakeDamage();
    }
}
