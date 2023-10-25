using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{
    public float moveSpeed;
    public bool milk;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
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
