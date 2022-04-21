using UnityEngine;

public class PanelSwitch : MonoBehaviour
{
    [SerializeField] private Panel _currentPanel;
    [SerializeField] private Panel _nextPanel;

    public void Switch()
    {
        _currentPanel.Close();
        _nextPanel.Open();
    }
}
