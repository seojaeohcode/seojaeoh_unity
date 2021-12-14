using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    public float speed;
    public int startIndex;
    public int endIndex;
    public Transform[] sprites;

    float viewHeight;
    // Start is called before the first frame update
    private void Awake()
    {
        viewHeight = Camera.main.orthographicSize * 2;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 curPos = transform.position;
        Vector3 nextPos = Vector3.down * speed * Time.deltaTime;
        transform.position = curPos + nextPos;

        if(sprites[endIndex].position.y<viewHeight*(-1))
        {
            Vector3 backSpritePos = sprites[startIndex].localPosition;
            Vector3 frontSpritePos = sprites[startIndex].localPosition;
            sprites[endIndex].transform.localPosition = backSpritePos + Vector3.up * viewHeight;

            int startIndexSave = startIndex;//2
            startIndex = endIndex;//start = 0
            Debug.Log(endIndex);
            endIndex = startIndexSave-1;// end==1
            if(endIndex < 0)
            {
                endIndex = 2;
            }
            Debug.Log(endIndex);
        }
    }
}
