using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneLauncher : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Image _buttonStub;
    [SerializeField] private TextMeshProUGUI _sceneIndexText;
    private string _sceneName;
    private Image _transitionImage;

    private void Start() => _transitionImage.transform.DOScale(0, 0);

    public void Init(string sceneName, int sceneIndex, Image transitionImage, GameSceneData gameSceneData)
    {
        _sceneName = sceneName;
        _sceneIndexText.text = sceneIndex.ToString();
        _startButton.gameObject.SetActive(gameSceneData.Opened);
        if (gameSceneData.Opened == false) _buttonStub.gameObject.SetActive(true);
        _transitionImage = transitionImage;
    }

    public void Load()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneName);
        operation.allowSceneActivation = false;
        _transitionImage.transform.DOScale(1, 1).onComplete = () => operation.allowSceneActivation = true;
    }
}
