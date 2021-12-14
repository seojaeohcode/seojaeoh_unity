using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    public GameObject bullet1;
    Vector3 vec;
    public float current;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        vec = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 0.5f, gameObject.transform.position.z);
        Fire();
    }

    void Fire()
    {
        Vector3 dir = player.transform.position - transform.position;
        current += 1.0f;
            if (current < 2.0f)
            {
                GameObject bullet = Instantiate(bullet1, vec, transform.rotation);
                Rigidbody2D rigid = bullet.GetComponent<Rigidbody2D>();
            rigid.AddForce(dir.normalized * 5f, ForceMode2D.Impulse);//gameObject.GetComponent<enemymove>().speed
            }
            else if (current > 300.0f)
            {
                current = 0;
                return;
            }
    }
}
