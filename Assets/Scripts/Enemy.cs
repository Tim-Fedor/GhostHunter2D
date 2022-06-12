using UnityEngine;
using UnityEngine.EventSystems;

public class Enemy : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] 
    private float moveSpeed;

    public void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        EventSystemController.Instance.DispatchEvent(EventConstants.DESTROY_ENEMY);
        Destroy(gameObject);
    }
}
