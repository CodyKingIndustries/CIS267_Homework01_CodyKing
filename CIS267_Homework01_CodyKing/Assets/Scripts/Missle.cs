using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    private bool moveUp;
    private float startY;
    public float offSet;
    public float movementSpeed;
    private Rigidbody2D missleRigidBody;

    void Start()
    {
        startY = transform.position.y;
        missleRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveMissile();
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

    private void moveMissile()
    {
        transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
        //missleRigidBody.velocity = new Vector2(- movementSpeed, missleRigidBody.velocity.y);
        if (moveUp)
        {
            transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.down * movementSpeed * Time.deltaTime);
        }

        if (transform.position.y >= startY)
        {
            moveUp = false;
        }
        if (transform.position.y <= startY - offSet)
        {
            moveUp = true;
        }
    }
}
