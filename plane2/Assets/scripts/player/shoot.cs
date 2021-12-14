using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public Transform firePos;
    public float current;
    GameObject curbullet;
    public int power = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bulletkind();
        Fire();
    }
    
    void Fire()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            current += 1.0f;
            if (current < 2.0f)
            {
                GameObject bullet = Instantiate(curbullet, firePos.position, transform.rotation);
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
                rigid.AddForce(Vector2.up * 10, ForceMode2D.Impulse);
                Debug.Log("shoot");
            }
            else if (current > 17.0f)
            {
                current = 0;
                return;
            }
        }
    }

    void bulletkind()
    {
        switch(power)
        {
            case 1:
                curbullet = bullet1;
                break;
            case 2:
                curbullet = bullet2;
                break;
            case 3:
                curbullet = bullet3;
                break;
            default:
                curbullet = bullet1;
                break;
        }
    }
}
