using UnityEngine;

public abstract class Money : MonoBehaviour
{
    [SerializeField] private AudioSource _receivingCrystalsSound;
    [SerializeField] private Animator _animator;
    [SerializeField] private Collider _collider;
    [SerializeField] private string _takeAnimationName;

    public void PlayDestructionAnimation()
    {
        _receivingCrystalsSound.Play();
        _collider.enabled = false;
        _animator.SetTrigger(_takeAnimationName);
    }
}
