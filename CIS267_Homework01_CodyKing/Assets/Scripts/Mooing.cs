using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mooing : MonoBehaviour
{
    public float speed;
    public GameObject[] milkDrops;
    public GameObject dollarDrop;
    public Transform spawnLocation;
    //private float randomMilk;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(dollarDrop, spawnLocation.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("OB") || collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("EnemyMilk"))
        {
            int randomIndex;
            randomIndex = Random.Range(0, milkDrops.Length);
            Instantiate(milkDrops[randomIndex], spawnLocation.position, transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
