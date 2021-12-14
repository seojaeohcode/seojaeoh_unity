using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public int damage; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "bulletline")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.tag == "enemy")
        {
            Destroy(gameObject);
        }
    }
}
