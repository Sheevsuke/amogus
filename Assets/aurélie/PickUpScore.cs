using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScore : MonoBehaviour
{
    [SerializeField] private int addScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        Score.instance.AddScore(addScore);
        // son collect
        Destroy(gameObject);
    }
}
