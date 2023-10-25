using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrawMooing : MonoBehaviour
{
    public float speed;
    public GameObject[] milkDrops;
    public GameObject dollarDrop;
    public Transform spawnLocation;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(dollarDrop, spawnLocation.position, transform.rotation);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("OB") || collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
