using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fantomespawn : MonoBehaviour
{
    [SerializeField] public GameObject[] fantomes;
    [SerializeField] public int countMax;
    [SerializeField] public int count = 0;
    [SerializeField] public float seconds = 5;
    [SerializeField] public Transform fantomeRespawn;

    void Start()
    {
        countMax = fantomes.Length;
        spawning();

    }

    public void spawning()
    {
        StartCoroutine(swapingCoroutine());
    }

    IEnumerator swapingCoroutine()
    {
        if (count < countMax)
        {
            Instantiate(fantomes[count]);
            count++;
            yield return new WaitForSeconds(seconds);
            spawning();

        }
        else
            yield return null;


    }
    public IEnumerator fantomesRespawn(GameObject fantome, int wait)
    {
        fantome.SetActive(false);
        yield return new WaitForSeconds(wait);
        fantome.SetActive(true);
        fantome.transform.position = fantomeRespawn.transform.position;


    }
}

