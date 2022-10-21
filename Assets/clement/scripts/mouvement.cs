using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mouvement : MonoBehaviour
{
    public Vector3 vec = Vector2.zero;
    public SpriteRenderer SpriteRenderer;
    public float speed = 5;
    public float bonusSpeed = 1;
    public float timeBonusMouvement = 5;
    public float timeBonusPlayer = 5;
    public Transform passage1, passage2;
    public Vector2 nextVec = Vector2.zero;
    public bool onCollision = false;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] public int vie = 3;
    [SerializeField] Transform respawn;
    public int scoreEnemiesKill = 200;
    

    

    void Update()
    {
        //listen des touches zqsd et changement du vecteur unitaire et verification de si il est en collision avec un mur
        // + ne pas aller dans la dirrection dans lequel il est aller lorsqu'il est rentré en collision avec le mur
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.LeftArrow))
            if ((onCollision && Vector2.left != nextVec) || !onCollision)
            {
                SpriteRenderer.flipX = false;
                vec = Vector2.left;

            }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            if ((onCollision && Vector2.right != nextVec) || !onCollision)
            {
                SpriteRenderer.flipX = true;
                vec = Vector2.right;

            }



        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.UpArrow))
            if ((onCollision && Vector2.up != nextVec) || !onCollision)
            {
                SpriteRenderer.flipY = true;
                vec = Vector2.up;

            }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            if ((onCollision && Vector2.down != nextVec) || !onCollision)
            {
                SpriteRenderer.flipY = false;
                vec = Vector2.down;

            }




    }
    private void FixedUpdate()
    {
        // deplacement (tjr mieux en fixed update)
        rb.MovePosition(rb.transform.position + (vec * Time.fixedDeltaTime * speed * bonusSpeed));
    }
    private void OnCollisionEnter2D(Collision2D collision )
    {
        if (collision.gameObject.layer == 6) //bonus de mouvement
        {
            bonusSpeed = 2;
            StartCoroutine(bonusMouvement(timeBonusMouvement));
            collision.gameObject.SetActive(false);

        }
        else if (collision.gameObject.layer == 7) // bonus de changement de form (quand tu peux tuer les fantomes)
        {
            Score.instance.AddScore(50);
            this.gameObject.tag = "playerTransform";
            StartCoroutine(waiting(timeBonusMouvement));
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == 8 && this.gameObject.tag == "playerTransform") // si on a le bonus de form et que tu touche un fantomes
        {
            Score.instance.AddScore(scoreEnemiesKill);
            if (scoreEnemiesKill != 1600)
                scoreEnemiesKill *= 2;

            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.layer == 8 && this.gameObject.tag == "Player") // si on touche un fantome sans le bonus
        {
            playerHit();
        }
        


    }
    private void OnTriggerEnter2D(Collider2D collision) // passages et teleport
    {
        if (collision.gameObject == passage1.gameObject)
            this.transform.position = new Vector2(passage2.position.x - 1f, passage2.position.y);
        else if (collision.gameObject == passage2.gameObject)
            this.transform.position = new Vector2(passage1.position.x + 1f, passage1.position.y);
        

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
    public void playerHit()
    {
        if (vie >= 1)
        {
            vie--;
            this.transform.position = respawn.position;
            vec = Vector2.zero;
            SpriteRenderer.flipY = false;
            SpriteRenderer.flipX = false;
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}

