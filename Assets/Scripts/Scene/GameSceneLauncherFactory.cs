using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AddressableAssets;

public class GameSceneLauncherFactory : MonoBehaviour
{
    [SerializeField] private AssetReference _gameSceneLauncherReference;
    [SerializeField] private Transform _gameSceneLauncherParent;
    [SerializeField] private List<string> _gameScenes;
    [SerializeField] private Image _transitionImage;
    [SerializeField] private SaveSystem _saveSystem;

    private void Start() => Produce();

    private void Produce()
    {
        foreach (var scene in _gameScenes)
        {
            int sceneIndex = _gameScenes.IndexOf(scene) + 1;
            var gameSceneData = sceneIndex == 1 ? new GameSceneData(true) : _saveSystem.Object<GameSceneData>(scene);
            var gameSceneLauncher = LocalAssetLoader.LoadAsset<GameSceneLauncher>(_gameSceneLauncherReference, _gameSceneLauncherParent);
            gameSceneLauncher.Init(scene, sceneIndex, _transitionImage, gameSceneData);
        }
    }
}
