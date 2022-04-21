using System;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public event Action<Collision> OnCollision;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _jumpForce;
    public bool Grounded { get; private set; }
    
    public void Run(Vector3 direction)
    {
        _rigidbody.MovePosition(transform.position + direction * _runSpeed);
        if (direction.magnitude > 0.1f)
            transform.rotation = Quaternion.LookRotation(direction);
    }
    
    public void Jump()
    { 
        if (Grounded)
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        Grounded = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        ContactPoint contactPoint = collision.GetContact(0);
        if (contactPoint.normal.y == 0)
            return;
        Grounded = true;
        OnCollision?.Invoke(collision);
    }
}
