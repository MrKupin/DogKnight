using UnityEngine;

public class Sword : Item
{
    private Animator _animator;

    public void Init(Animator animator, Transform transform)
    {
        _animator = animator;
        this.transform.parent = transform;
        this.transform.position = transform.position;
        this.transform.rotation = transform.rotation;

    }
    
    public void Attack() => _animator.SetTrigger("Attack");

    private void OnTriggerEnter(Collider other)
    {
        if (_animator.GetCurrentAnimatorStateInfo(1).IsName("Attack") == false) return;
        if (other.gameObject.TryGetComponent(out IDeath death))
            death.Kill();
        if (other.gameObject.TryGetComponent(out IArmor thorns))
            thorns.Destroy();
    }
}
