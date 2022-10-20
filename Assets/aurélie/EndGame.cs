using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] private int _pelletLeft;

    void Update()
    {
        _pelletLeft = transform.childCount;
        if (_pelletLeft == 0) // no pellet left > end game
            Time.timeScale = 0;
    }
}
