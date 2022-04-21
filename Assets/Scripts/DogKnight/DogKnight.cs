using System;
using UnityEngine;
using UnityEngine.VFX;

public class DogKnight : MonoBehaviour, IMovement, IHealth
{
    public event Action OnDie;
    [SerializeField] private MoneyCollector _moneyCollector;
    [SerializeField] private CharacterHealth _characterHealth;
    [SerializeField] private AudioSource _cuttingMeatSound;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private Animator _animator;
    [SerializeField] private VisualEffect _bloodVisualEffect;
    [SerializeField] private Transform _swordPosition;
    [SerializeField] private DecalProjector _shadowProjector;
    private Sword _sword;

    public void Init(Sword sword, Transform startTransform)
    {
        transform.position = startTransform.position;
        transform.rotation = startTransform.rotation;
        _sword = sword;
        _sword.Init(_animator, _swordPosition);
        _characterMovement.OnCollision += TouchWithFeet;
    }

    public void Attack() => _sword.Attack();

    public void TakeDamage()
    {
        _cuttingMeatSound.Play();
        _animator.SetTrigger("TakeDamage");
        _bloodVisualEffect.Play();
        _characterHealth.TakeDamage();
        if (_characterHealth.NumberHearts <= 0) Kill();
    }

    public void Kill()
    {
        _animator.SetTrigger("Die");
        OnDie?.Invoke();
    }

    public void Run(Vector3 direction)
    {
        _characterMovement.Run(direction);
        _animator.SetFloat("Run", direction.magnitude);
    }

    public void Jump()
    {
        _characterMovement.Jump();
        if (_characterMovement.Grounded == false) _shadowProjector.Enable();
    }

    private void TouchWithFeet(Collision collision)
    {
        _shadowProjector.Disable();
        if (collision.gameObject.TryGetComponent(out ITrampoline trampoline))
            trampoline.Push(this);
        if (collision.gameObject.TryGetComponent(out IDust dust))
            dust.MakeDusty(transform.position);
        if (collision.gameObject.TryGetComponent(out IDeath death))
            death.Kill();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent(out Money money)) return;
        _moneyCollector.Collect(money);
        money.PlayDestructionAnimation();
    }

    private void OnDestroy()
    {
        _moneyCollector.BankTransfer();
        _characterMovement.OnCollision -= TouchWithFeet;
    }
}
