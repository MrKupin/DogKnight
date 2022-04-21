using UnityEngine;
using UnityEngine.EventSystems;

public class Victory : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Panel _victoryPanel;
    [SerializeField] private SaveSystem _saveSystem;
    private EventSystem _eventSystem;
    private string _nextGameSceneName;

    private void Start() => _victoryPanel.Close();

    public void Init(string nextGameSceneName, EventSystem eventSystem)
    {
        _nextGameSceneName = nextGameSceneName;
        _eventSystem = eventSystem;
    }

    public void Win()
    {
        _victoryPanel.Open();
        _eventSystem.enabled = false;
        _eventSystem.enabled = true;
        _joystick.Disable();
        GameSceneData gameSceneData = new GameSceneData(true);
        _saveSystem.Save(_nextGameSceneName, gameSceneData);
    }
}
