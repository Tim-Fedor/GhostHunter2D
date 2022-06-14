using com.GhostHunter.BaseSystems;
using TMPro;
using UnityEngine;
using Zenject;

namespace com.GhostHunter.UI
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] 
        private TMP_Text _text;
        private int _score;
        private IEventSystemService _eventSystemService; 

        [Inject]
        private void Construct(IEventSystemService eventSystemService)
        {
            _eventSystemService = eventSystemService;
            _eventSystemService.AddListener(EventConstants.DESTROY_ENEMY, UpdateScore);
        }
    
        private void UpdateScore(object[] data)
        {
            if (data == null || data.Length < 1)
            {
                return;
            }

            if (data[0] is bool && (bool)data[0]) 
            {
                _score++;
                _text.text = _score.ToString();
            }

        }

        private void OnDestroy()
        {
            _eventSystemService.RemoveListener(EventConstants.DESTROY_ENEMY, UpdateScore);
        }
    }
}
