using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class manger : MonoBehaviour
{
    dino dino;
    enemsSpawner enemsSpawner;
    movimentodochao movimentodochao;

    bool gameOver = false;

    float timeToIncreaseDifficulty = 0;
    float interval = 5f;

    public Text scoreText;
    int score;

    void Start()
    {
        dino = FindAnyObjectByType<dino>();
        enemsSpawner = FindAnyObjectByType<enemsSpawner>();
        movimentodochao = FindAnyObjectByType<movimentodochao>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {

            if (Physics2D.OverlapBoxAll(dino.transform.position, Vector2.one * 0.3f, 0, LayerMask.GetMask("enemy")).Length > 0)
            {
                gameOver = true;

                enemsSpawner.stopEnemy = true;

                movimentodochao.speed = 0;

                cactu[] allCactos = FindObjectsOfType<cactu>();
                foreach (cactu obj in allCactos)
                    obj.speed = 0;

            }

            if(Time.time >= timeToIncreaseDifficulty)
            {
                enemsSpawner.speed += 0.2f;
                movimentodochao.speed += 0.2f;

                score += 100;
                scoreText.text = score.ToString("D4");


                timeToIncreaseDifficulty = Time.time + interval;
            }


        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
