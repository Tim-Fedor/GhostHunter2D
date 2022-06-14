using System.Collections;
using System.Collections.Generic;
using GhostHunter;
using TMPro;
using UnityEngine;
using Zenject;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text _text;
    private int _score;

    [Inject]
    private void Construct(IEventSystemService eventSystemService)
    {
        eventSystemService.AddListener(EventConstants.DESTROY_ENEMY, UpdateScore);
    }
    
    private void UpdateScore()
    {
        _score++;
        _text.text = _score.ToString();
    }
}
