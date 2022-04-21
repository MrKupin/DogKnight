using System;
using UnityEngine;

public class CheckPoint : MonoBehaviour, IGameOver
{
    public event Action OnFinish;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out DogKnight dogKnight))
            OnFinish?.Invoke();
    }
}
