using UnityEngine;
using UnityEngine.EventSystems;

public class DogKnightSystem : MonoBehaviour
{
    [SerializeField] private DogKnight _dogKnight;

    [SerializeField] private Victory _victory;

    [SerializeField] private Loss _loss;

    public void Init(Sword sword, Transform startTransform, IGameOver gameOver, EventSystem eventSystem, string nextGameSceneName)
    {
        _dogKnight.Init(sword, startTransform);
        _victory.Init(nextGameSceneName, eventSystem);
        _loss.Init(eventSystem);
        gameOver.OnFinish += _victory.Win;
    }
}
