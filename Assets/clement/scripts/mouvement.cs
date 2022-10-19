using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    public Vector2 vec = new Vector2(0, 0);
    public float speed = 10;
    public float bonusSpeed = 1;
    public float timeBonus = 5;


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            vec = new Vector2(-1, 0);
        if (Input.GetKeyDown(KeyCode.D))
            vec = new Vector2(1, 0);

        if (Input.GetKeyDown(KeyCode.Z))
            vec = new Vector2(0, 1);

        if (Input.GetKeyDown(KeyCode.S))
            vec = new Vector2(0, -1);




    }
    private void FixedUpdate()
    {
        this.transform.Translate(vec * Time.deltaTime * speed * bonusSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            bonusSpeed = 2;
            StartCoroutine(bonus(timeBonus));
            collision.gameObject.SetActive(false);

        }
        else if (collision.gameObject.layer == 7)
        {
            this.gameObject.tag = "playerTransform";
            StartCoroutine(waiting(timeBonus));
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.layer == 8 && this.gameObject.tag == "playerTransform")
        {
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.layer == 8 && this.gameObject.tag == "Player")
        {
            //playerhit
        }


    }
    IEnumerator bonus(float temps)
    {

        yield return new WaitForSeconds(temps);
        bonusSpeed = 1;

    }
    IEnumerator waiting(float temps)
    {
        yield return new WaitForSeconds(temps);
        this.gameObject.tag = "Player";



    }
}

