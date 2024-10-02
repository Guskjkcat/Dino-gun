using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public ParticleSystem muzzleFlash;
    public ParticleSystem capsules;

    Camera cam;

    public GameObject shot;
    public GameObject shotSpwan;

    float shotInterval = 0.1f;
    float shotIntantiateTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        muzzleFlash.Stop();
        capsules.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        transform.right = (mousePosition - (Vector2)transform.position).normalized;

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            muzzleFlash.Play();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            muzzleFlash.Stop();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            capsules.Play();
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            capsules.Stop();
        }


        if (Input.GetKey(KeyCode.Mouse0))
        {
            if(Time.time >= shotIntantiateTime)
            {
                Instantiate(shot, shotSpwan.transform.position, transform.rotation);
                shotIntantiateTime = Time.time + shotInterval;
            }

            
        }
    }
}
