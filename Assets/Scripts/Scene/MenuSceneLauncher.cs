using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuSceneLauncher : MonoBehaviour
{
    [SerializeField] private Image _transitionImage;

    private void Start()
    {
        _transitionImage.transform.DOScale(0, 0);
    }

    public void LoadMainMenu()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(0);
        operation.allowSceneActivation = false;
        _transitionImage.transform.DOScale(1, 1).onComplete = () => operation.allowSceneActivation = true;
    }
}
