using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{
    public float speed;
    public int health;
    Rigidbody2D rigid;
    public GameObject player;
    public int enemyscore;
    public GameObject item;
    // Start is called before the first frame update
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = Vector2.down * speed;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bulletline")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "bullet")
        {
            Debug.Log("hit");
            bullet bullet = collision.gameObject.GetComponent<bullet>();
            health -= bullet.damage;

            if (health <= 0)
            {
                player.GetComponent<UI>().score+=enemyscore;
                int randomnum = Random.Range(0, 100);
                if(randomnum>80)
                {
                    spawnpower();
                }
                Destroy(gameObject);
            }
        }
    }

    void spawnpower()
    {
        Instantiate(item, gameObject.transform.position, gameObject.transform.rotation);
    }
}
