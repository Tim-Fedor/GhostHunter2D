using com.GhostHunter.BaseSystems;
using com.GhostHunter.Settings;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace com.GhostHunter.Entity
{
    public class Enemy : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] 
        private float moveSpeed;
    
        private IEventSystemService _eventSystemService;
        private PathPoints _path;
        private Vector3 _moveDirection;
        private bool _isKilled;

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
            _isKilled = true;
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            _eventSystemService.DispatchEvent(EventConstants.DESTROY_ENEMY, _isKilled);
        }
    }
}
