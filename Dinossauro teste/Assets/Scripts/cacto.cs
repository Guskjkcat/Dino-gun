using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactu : MonoBehaviour
{
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x <= -6)
        {
            Destroy(gameObject);
        }
    }
}
