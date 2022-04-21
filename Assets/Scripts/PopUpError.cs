using DG.Tweening;
using TMPro;
using UnityEngine;

public class PopUpError : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _errorText;

    private void Start()
    {
        _errorText.DOFade(0, 0);
    }

    public void PopUp()
    {
        _errorText.DOFade(1, 0);
        _errorText.DOFade(0, 3);
    }
}
