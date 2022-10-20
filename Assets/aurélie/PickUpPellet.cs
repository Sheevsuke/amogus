using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPellet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;
        Score.instance.AddScore(10);
        // son collect
        Destroy(gameObject);
    }
}
