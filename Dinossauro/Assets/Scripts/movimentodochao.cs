using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentodochao : MonoBehaviour
{
    public Sprite[] groundSprites;

    public SpriteRenderer[] grounds;

    public float speed = 3;

    Vector2 endPosition = new Vector2(-5.72f, -1f);
    Vector2 startPosition = new Vector2(6.162f, -1f);

    void Start()
    {
        

    }

    
    void Update()
    {
        for (int i = 0; i < grounds.Length; i++)
        {
            grounds[i].transform.position += Vector3.left * speed * Time.deltaTime;

            if (grounds[i].transform.position.x <= endPosition.x)
            {
                grounds[i].transform.position = startPosition;
                grounds[i].sprite = groundSprites[Random.Range(0,groundSprites.Length)];
            }
        }
    }
}
