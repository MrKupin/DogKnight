using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Vector3 _firstTarget;
    [SerializeField] private Vector3 _secondTarget;
    private Vector3 _currentTarget;

    private void Start() => transform.position = _firstTarget;

    private void FixedUpdate()
    {
        SetTarget();
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _moveSpeed);
    }

    private void SetTarget()
    {
        if (transform.position == _firstTarget)
            _currentTarget = _secondTarget;
        else if (transform.position == _secondTarget)
            _currentTarget = _firstTarget;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IHealth health))
            health.TakeDamage();
    }
}
