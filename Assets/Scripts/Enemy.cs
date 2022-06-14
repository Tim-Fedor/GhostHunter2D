using GhostHunter;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Enemy : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] 
    private float moveSpeed;
    
    private IEventSystemService _eventSystemService; 

    [Inject]
    private void Construct(IEventSystemService eventSystemService)
    {
        _eventSystemService = eventSystemService;
    }

    public void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _eventSystemService.DispatchEvent(EventConstants.DESTROY_ENEMY);
        Destroy(gameObject);
    }
}
