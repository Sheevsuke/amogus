using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private int _scoreCount;
    [SerializeField] private Text _scoreCountText;

    public static Score instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Score dans la scène");
            return;
        }

        instance = this;
    }

    public void AddScore(int count)
    {
        _scoreCount += count;
        _scoreCountText.text = _scoreCount.ToString();
    }
}
