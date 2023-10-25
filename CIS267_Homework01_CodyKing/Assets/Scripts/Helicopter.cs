using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : MonoBehaviour
{
    private Rigidbody2D heliRigidBody;
    public Transform center;
    public float movementSpeed;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        heliRigidBody = GetComponent<Rigidbody2D>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        helicopterMovement();
    }

    void helicopterMovement()
    {
        timer += Time.deltaTime;
        if (timer >= 0 && timer <= 5)
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        }
        else if (timer < 7)
        {
            transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
        }
        else
        {
            timer = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Ouchie");
        }
        if (collision.gameObject.CompareTag("Deleter"))
        {
            //Debug.Log("Destroyed");
            Object.Destroy(gameObject);
        }
    }
}
