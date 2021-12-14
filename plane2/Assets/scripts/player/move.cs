using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed;
    public bool isoutNorth;
    public bool isoutSouth;
    public bool isoutEast;
    public bool isoutWest;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if ((isoutEast && h == 1)|| (isoutWest && h == -1))
            h = 0;
        float v = Input.GetAxisRaw("Vertical");
        if ((isoutNorth && v == 1) || (isoutSouth && v == -1))
            v = 0;
        Vector3 curPos = transform.position;
        Vector3 nextPos = new Vector3(h, v, 0) * speed * Time.deltaTime;

        transform.position = curPos + nextPos;

        /*
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("오른쪽");
            transform.position = new Vector2(transform.position.x + 0.01f, 0)*Time.time;
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("왼쪽");
            transform.position = new Vector2(transform.position.x - 0.01f, 0) * Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("위쪽");
            transform.position = new Vector2(0, transform.position.y - 0.01f) * Time.time;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("아래쪽");
            transform.position = new Vector2(0, transform.position.y + 0.01f) * Time.time;
        }
        */

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            switch(collision.gameObject.name)
            {
                case "north":
                    isoutNorth = true;
                    break;
                case "south":
                    isoutSouth = true;
                    break;
                case "east":
                    isoutEast = true;
                    break;
                case "west":
                    isoutWest = true;
                    break;
            }
        }
        else if(collision.gameObject.tag == "enemy" || collision.gameObject.tag == "enemybullet")
        {
            
            gameObject.GetComponent<UI>().life--;
            gameManager.lifeiconupdate(gameObject.GetComponent<UI>().life);
            if(gameObject.GetComponent<UI>().life == 0)
            {
                gameManager.gameover();
            }
            else
            {
                gameManager.RespawnPlayer();
            }
            
            gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
        else if(collision.gameObject.tag == "power")
        {
            if(gameObject.GetComponent<shoot>().power<3)
            gameObject.GetComponent<shoot>().power += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            switch (collision.gameObject.name)
            {
                case "north":
                    isoutNorth = false;
                    break;
                case "south":
                    isoutSouth = false;
                    break;
                case "east":
                    isoutEast = false;
                    break;
                case "west":
                    isoutWest = false;
                    break;
            }
        }
    }
}
