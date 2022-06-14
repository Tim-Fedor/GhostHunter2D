using System;
using GhostHunter;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Enemy : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] 
    private float moveSpeed;
    
    private IEventSystemService _eventSystemService;
    private PathPoints _path;
    private Vector3 _moveDirection;
    private float _diff;

    [Inject]
    private void Construct(IEventSystemService eventSystemService, PathPoints path)
    {
        _eventSystemService = eventSystemService;
        _path = path;
    }

    private void Start()
    {
        _moveDirection = _path.finalPosition - _path.startPosition;
    }

    private void Update()
    {
        transform.Translate(_moveDirection * Time.deltaTime * moveSpeed);
        
        if (Vector3.Distance(_path.finalPosition, transform.position) <= 5f)
        {
            Destroy(gameObject);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _eventSystemService.DispatchEvent(EventConstants.DESTROY_ENEMY);
    }
}
