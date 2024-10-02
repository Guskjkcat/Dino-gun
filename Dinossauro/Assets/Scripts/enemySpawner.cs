using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemsSpawner : MonoBehaviour
{
    struct SpawnTime
    {
        public float instantianteTime;
        public float interval;
        public float variation;

    }

    public Sprite[] cactusSprites;

    public GameObject cactusPrefebs;

    public GameObject dinoFlyPrefebs;

    float dinoFlyMax = 2;
    float dinoFlyMin = -1;


    SpawnTime cactus;
    SpawnTime dinoFly;

    public bool stopEnemy = false;
    public float speed = 4; 

    // Start is called before the first frame update
    void Start()
    {

        cactus.instantianteTime = 0f;
        cactus.interval = 2f;
        cactus.variation = 0.5f;

        dinoFly.instantianteTime = 0f;
        dinoFly.interval = 2f;
        dinoFly.variation = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {

        //Surgimento do cacto
        if(Time.time > cactus.instantianteTime && !stopEnemy)
        {
            GameObject obj = Instantiate(cactusPrefebs, new Vector3(5, -0.9f), Quaternion.identity);
            obj.GetComponent<SpriteRenderer>().sprite = cactusSprites[Random.Range(0, cactusSprites.Length)];
            obj.AddComponent<BoxCollider2D>();
            obj.GetComponent<cactu>().speed = speed;
            cactus.instantianteTime = Time.time + Random.Range(cactus.interval - cactus.variation, cactus.interval + cactus.variation);
        }


        //Surgimento do DinoFly
        if (Time.time > dinoFly.instantianteTime && !stopEnemy)
        {
            GameObject obj = Instantiate(dinoFlyPrefebs, new Vector3(5, Random.Range(dinoFlyMax, dinoFlyMin)), Quaternion.identity);
            dinoFly.instantianteTime = Time.time + Random.Range(dinoFly.interval - dinoFly.variation, dinoFly.interval + dinoFly.variation);
        }

    }
}
