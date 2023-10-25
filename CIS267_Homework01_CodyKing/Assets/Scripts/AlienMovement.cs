using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D alienRigidBody;
    public float inputHorizontal;
    public float movementSpeed;
    public float jumpForce;
    public float moveIncrease;

    public GameObject gameManager;
    private GameManager gm;
    public GameObject cowMovement;

    void Start()
    {
        alienRigidBody = GetComponent<Rigidbody2D>();
        gm = gameManager.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moveAlienLateral();
        alienJump();
    }

    private void moveAlienLateral()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        moveTimer();
        alienRigidBody.velocity = new Vector2(movementSpeed * moveIncrease * inputHorizontal, alienRigidBody.velocity.y);
        //alienRigidBody.velocity = new Vector2(cowMovement.GetComponent<Rigidbody2D>().velocity.x, alienRigidBody.velocity.y);
    }

    private void alienJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            alienRigidBody.velocity = new Vector2(alienRigidBody.velocity.x, jumpForce);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dollar"))
        {
            int collectableValue = collision.GetComponent<Collectibles>().getCollectableValue();
            collision.GetComponent<Collectibles>().destroyCollectable();
            GetComponent<AlienScore>().setAlienScore(collectableValue);
        }
        if (collision.gameObject.CompareTag("Milk"))
        {
            int collectableValue = collision.GetComponent<Collectibles>().getCollectableValue();
            string milkType = collision.GetComponent<Collectibles>().getMilkType();
            collision.GetComponent<Collectibles>().destroyCollectable();
            GetComponent<AlienScore>().setAlienScore(collectableValue);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OB"))
        {
            
        }
        else if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyMilk") || collision.gameObject.CompareTag("Player"))
        {
            gm.setGameOver(true);
        }
    }

    void moveTimer()
    {
        if (inputHorizontal != 0)
        {
            if (moveIncrease < 3)
            {
                moveIncrease += Time.deltaTime;
            }
        }
        else
        {
            moveIncrease = 1;
        }
    }
}
