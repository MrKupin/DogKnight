using UnityEngine;

public class Platform : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out IHealth health))
            health.TakeDamage();
    }
}
