using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLauncher : MonoBehaviour
{
    [SerializeField] private Image _transitionImage;

    private void Start() => _transitionImage.transform.DOScale(0, 0);

    public void LoadMenu() => LoadScene(0);

    public void Restart() => LoadScene(SceneManager.GetActiveScene().buildIndex);

    private void LoadScene(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        operation.allowSceneActivation = false;
        _transitionImage.transform.DOScale(1, 1).onComplete = () => operation.allowSceneActivation = true;
    }
}
