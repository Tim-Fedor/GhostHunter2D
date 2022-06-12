using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] 
    private TMP_Text _text;
    private int _score;
    private void Start()
    {
        EventSystemController.Instance.AddListener(EventConstants.DESTROY_ENEMY, UpdateScore);
    }
    
    private void UpdateScore()
    {
        _score++;
        _text.text = _score.ToString();
    }
}
