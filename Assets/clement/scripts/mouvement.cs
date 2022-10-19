using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouvement : MonoBehaviour
{
    public Vector2 vec = new Vector2(0, 0);
    public float speed = 10;
    public float bonusSpeed = 1;
    public float timeBonusMouvement = 5;
    public float timeBonusPlayer = 5;


    void Update()
    {
        //listen des touches zqsd et changement du vecteur unitaire
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
        // deplacement (tjr mieux en fixed update)
        this.transform.Translate(vec * Time.deltaTime * speed * bonusSpeed);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) //bonus de mouvement
        {
            bonusSpeed = 2;
            StartCoroutine(bonusMouvement(timeBonusMouvement));
            collision.gameObject.SetActive(false);

        }
        else if (collision.gameObject.layer == 7) // bonus de changement de form (quand tu peux tuer les fantomes)
        {
            this.gameObject.tag = "playerTransform";
            StartCoroutine(waiting(timeBonusMouvement));
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.layer == 8 && this.gameObject.tag == "playerTransform") // si on a le bonus de form et que tu touche un fantomes
        {
            collision.gameObject.SetActive(false);
        }
        else if (collision.gameObject.layer == 8 && this.gameObject.tag == "Player") // si on touche un fantome sans le bonus
        {
            //playerhit
        }


    }
    IEnumerator bonusMouvement(float temps) 
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

