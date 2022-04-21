using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] private HeartsView _heartsView;

    [SerializeField] private int _numberHearts;

    public int NumberHearts => _numberHearts;

    public void Start()
    {
        _heartsView.CreateHearts(_numberHearts);
    }
    
    public void TakeDamage()
    {
        _heartsView.RemoveHeart();
        _numberHearts--;
    }
}
