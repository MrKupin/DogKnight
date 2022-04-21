using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;

public class GameStart : MonoBehaviour
{
    [SerializeField] private AssetReference _dogKnightSystemReference;
    [SerializeField] private Transform _dogKnightStartTransform;
    [SerializeField] private CheckPoint _checkPoint;
    [SerializeField] private string _nextGameSceneName;
    [SerializeField] private SaveSystem _saveSystem;
    [SerializeField] private EventSystem _eventSystem;

    private void Start()
    {
        string selectedSwordFileName = FileNames.SelectedItems.SelectedSword.ToString();
        SelectedItem selectedSword = _saveSystem.Object<SelectedItem>(selectedSwordFileName);
        Sword sword = LocalAssetLoader.LoadAsset<Sword>(selectedSword.AssetReference);
        var dogKnightSystem = LocalAssetLoader.LoadAsset<DogKnightSystem>(_dogKnightSystemReference);
        dogKnightSystem.Init(sword, _dogKnightStartTransform, _checkPoint, _eventSystem, _nextGameSceneName);
    }
}
