using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class shot : MonoBehaviour
{
    float speed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        if(transform.position.x >= 6)
        {
            Destroy(gameObject);
        }
    }
}
