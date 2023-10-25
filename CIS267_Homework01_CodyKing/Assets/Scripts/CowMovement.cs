using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting.ReorderableList;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CowMovement : MonoBehaviour
{
    //Only way I could get my jump to work, it is sticky otherwise
    //[SerializeField] private LayerMask groundLayerMask;
    public AudioSource m_AudioSource;

    private Rigidbody2D cowRigidBody;
    private PolygonCollider2D cowCollider;
    public float movementSpeed;
    public float inputHorizontal;
    public float jumpForce;
    public float moveIncrease;
    //public float maxJumpHeight;
    private bool isGrounded;
    private string milkType;
    //private bool inUFO;

    public GameObject gameManager;
    private GameManager gm;

    public Transform gunLocation;
    public Transform strawLocation;
    public Mooing mooProjo;
    public Mooing mooBig;
    public StrawMooing mooStraw;
    private float mooTimer;
    
    // Start is called before the first frame update
    void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
        cowRigidBody = GetComponent<Rigidbody2D>();
        cowCollider = GetComponent<PolygonCollider2D>();
        moveIncrease = 1;
        //cowRigidBody.GetComponent<AlienMovement>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Update");
        jump();
        moveCowLateral();
        firingMoo();
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    inUFO = true;
        //}
        //if (isGrounded == true)
        //{
        //    inUFO = false;
        //    endUFO();
        //}
    }

    private void moveCowLateral()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        moveTimer();
        cowRigidBody.velocity = new Vector2(movementSpeed * moveIncrease * inputHorizontal, cowRigidBody.velocity.y);
        //moveIncrease += Time.deltaTime;
    }

    private void jump()
    {
        grounded();
        if ((Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) || (Input.GetKeyDown(KeyCode.W) && isGrounded))
        {
            cowRigidBody.velocity = new Vector2(cowRigidBody.velocity.x, jumpForce);
            cowRigidBody.gravityScale = 6;
            isGrounded = false;
        }
        else if ((Input.GetKeyUp(KeyCode.UpArrow) && isGrounded == false) || (Input.GetKeyUp(KeyCode.W) && isGrounded == false))
        {
            cowRigidBody.gravityScale = 16;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            cowRigidBody.gravityScale = 36;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("OB"))
        {
            gm.setGameOver(true);
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyMilk") || collision.gameObject.CompareTag("Player"))
        {
            gm.setGameOver(true);
        }
    }

    private void grounded()
    {
        RaycastHit2D raycastCow = Physics2D.BoxCast(cowCollider.bounds.center, cowCollider.bounds.size, 0f, Vector2.down * .01f);
        if (raycastCow.collider != null)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Dollar"))
        {
            int collectableValue = collision.GetComponent<Collectibles>().getCollectableValue();
            collision.GetComponent<Collectibles>().destroyCollectable();
            GetComponent<PlayerScore>().setPlayerScore(collectableValue);
        }
        if (collision.gameObject.CompareTag("Milk"))
        {
            int collectableValue = collision.GetComponent<Collectibles>().getCollectableValue();
            milkType = collision.GetComponent<Collectibles>().getMilkType();
            collision.GetComponent<Collectibles>().destroyCollectable();
            GetComponent<PlayerScore>().setPlayerScore(collectableValue);
        }
        //if (collision.gameObject.CompareTag("Player") && inUFO == false)
        //{
        //    cowRigidBody.GetComponent<AlienMovement>().enabled = true;
        //    cowRigidBody.gravityScale = 1;
        //}
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

    private void firingMoo()
    {
        mooTimer += Time.deltaTime;
        if (milkType == "chocolate")
        {
            if (Input.GetKeyDown(KeyCode.Z) && mooTimer > 2.5)
            {
                Instantiate(mooProjo, gunLocation.position, transform.rotation);
                m_AudioSource.Play();
                mooTimer = 0;
            }
        }
        if (milkType == "strawberry")
        {
            {
                if (Input.GetKeyDown(KeyCode.Z) && mooTimer > 5)
                {
                    Instantiate(mooProjo, gunLocation.position, transform.rotation);
                    Instantiate(mooStraw, strawLocation.position, transform.rotation);
                    m_AudioSource.Play();
                    mooTimer = 0;
                }
            }
        }
        if (milkType == "white")
        {
            if (Input.GetKeyDown(KeyCode.Z) && mooTimer > 5)
            {
                Instantiate(mooBig, gunLocation.position, transform.rotation);
                m_AudioSource.Play();
                mooTimer = 0;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z) && mooTimer > 5)
            {
                Instantiate(mooProjo, gunLocation.position, transform.rotation);
                m_AudioSource.Play();
                mooTimer = 0;
            }
        }
    }
    //private void endUFO()
    //{
    //    cowRigidBody.GetComponent <AlienMovement>().enabled = false;
    //    cowRigidBody.gravityScale = 6;
    //}
}
