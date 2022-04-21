using UnityEngine;
using UnityEngine.EventSystems;

public class Loss : MonoBehaviour
{
    [SerializeField] private DogKnight _dogKnight;
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Panel _lossPanel;
    private EventSystem _eventSystem;

    private void Start()
    {
        _lossPanel.Close();
        _dogKnight.OnDie += Lose;
    }

    public void Init(EventSystem eventSystem) => _eventSystem = eventSystem;

    public void Lose()
    {
        _lossPanel.Open();
        _eventSystem.enabled = false;
        _eventSystem.enabled = true;
        _joystick.Disable();
    }

    private void OnDestroy() => _dogKnight.OnDie -= Lose;
}
