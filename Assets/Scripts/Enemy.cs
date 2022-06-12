using GhostHunter;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Enemy : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] 
    private float moveSpeed;
    
    private IEventSystemController _eventSystemController; 

    [Inject]
    private void Construct(IEventSystemController eventSystemController)
    {
        _eventSystemController = eventSystemController;
    }

    public void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _eventSystemController.DispatchEvent(EventConstants.DESTROY_ENEMY);
        Destroy(gameObject);
    }
}
