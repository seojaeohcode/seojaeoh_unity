using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemyObj;
    public Transform[] spawnPoint;

    public float SpawnDelay;

    public GameObject player;
    //public Text ScoreText;
    public Image[] lifeimage;
    public GameObject gameoverset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnDelay += Time.deltaTime;

        if(SpawnDelay > Random.Range(1.0f, 2.5f))
        {
            SpawnEnemy();
            SpawnDelay = 0;
        }

    }

    void SpawnEnemy()
    {
        int randomEnemy = 0;
        int randomnum = Random.Range(0, 100);
        int randomPoint = Random.Range(0, 5);

        if(randomnum >= 0 && randomnum <= 80)
        {
            randomEnemy = 0;
        }
        else if(randomnum >= 81 && randomnum <= 95)
        {
            randomEnemy = 1;
        }
        else if (randomnum >= 96 && randomnum <= 100)
        {
            randomEnemy = 2;
        }

        GameObject enemy = Instantiate(enemyObj[randomEnemy], spawnPoint[randomPoint].position, spawnPoint[randomPoint].rotation);
        enemybullet passvalue = enemy.GetComponent<enemybullet>();
        passvalue.player = player;
        enemy.GetComponent<enemymove>().player = GameObject.Find("비행기");
    }

    public void RespawnPlayer()
    {
        Invoke("RespawnPlayerexe", 2f);
    }
    void RespawnPlayerexe()
    {
        player.transform.position = Vector3.down * 3.0f;
        player.SetActive(true);
    }
    
    public void lifeiconupdate(int life)
    {
        for (int i = 0; i < 3; i++)
        {
            lifeimage[i].color = new Color(1, 1, 1, 0);
        }

        for (int i=0; i<life; i++)
        {
            lifeimage[i].color = new Color(1, 1, 1, 1);
        }
    }

    public void gameover()
    {
        gameoverset.SetActive(true);
    }
    
    public void gameretry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Quit()
    {
        Debug.Log("종료");
        Application.Quit();
    }

    public void scoreup()
    {
        //UI playerScore = player.GetComponent<UI>(); player.GetComponent<UI>().score
        //ScoreText.text = string.Format("{0:n0}", player.GetComponent<UI>().score);
        //ScoreText.text = player.GetComponent<UI>().score.ToString();
    }
}