using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _stick;
    [SerializeField] private Image _background;
    [SerializeField] private DogKnight _dogKnight;

    private void FixedUpdate() 
    {
        _dogKnight.Run(Direction());
    }

    public void OnDrag(PointerEventData eventData)
    {
        float radius = _background.rectTransform.rect.width / 2;
        _stick.transform.position = eventData.position;
        if (_stick.transform.localPosition.magnitude > radius)
            _stick.transform.localPosition = _stick.transform.localPosition.normalized * radius;
    }

    public void OnPointerDown(PointerEventData eventData) { }
    public void OnPointerUp(PointerEventData eventData)
    {
        _stick.transform.localPosition = Vector3.zero;
    }

    private Vector3 Direction()
    {
        Vector3 direction = _stick.transform.localPosition.normalized;
        return new Vector3(direction.x, 0, direction.y);
    }

    public void Disable()
    {

        gameObject.SetActive(false);
    }
}
