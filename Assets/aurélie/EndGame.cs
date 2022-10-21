using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private int _pelletLeft;

    [SerializeField] private GameObject _winScreen;
    [SerializeField] private Text _scoreCount;
    [SerializeField] private GameObject _scoreCountGame;

    [SerializeField] private Score _score;

    void Update()
    {
        _pelletLeft = transform.childCount;
        if (_pelletLeft == 0) // no pellet left > end game
        {
            Time.timeScale = 0;
            _scoreCountGame.SetActive(false);
            _winScreen.SetActive(true);
            _scoreCount.text = _score.scoreCount.ToString();
        }
    }
}
