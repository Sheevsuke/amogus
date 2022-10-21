using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpScore : MonoBehaviour
{
    [SerializeField] private int addScore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("playerTransform"))
        {
            Score.instance.AddScore(addScore);
            Destroy(gameObject);
        }
        

        // son collect
    }
}
