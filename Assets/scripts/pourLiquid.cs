using UnityEngine;
using System.Collections;

public class pourLiquid : MonoBehaviour

{

    Vector3 touchPosWorld;

    //Change me to change the touch phase used.
    TouchPhase touchPhase = TouchPhase.Ended;

    void Update()

    {

        Debug.Log(transform.rotation.eulerAngles.x);
        Debug.Log(transform.rotation.eulerAngles.y);
        Debug.Log(transform.rotation.eulerAngles.z);


        //float x = transform.rotation.eulerAngles.x;
        //float y = transform.rotation.eulerAngles.y;
        //float z = transform.rotation.eulerAngles.z;

        Vector3 pos = transform.rotation * Vector3.up;

        GameObject particles = GameObject.Find("Particle System");

        if (Vector3.Dot(Vector3.up, pos) < 0)
        {
            particles.GetComponent<ParticleSystem>().enableEmission = true;
            Debug.Log(true);
        }
        else
        {
            particles.GetComponent<ParticleSystem>().enableEmission = false;
            Debug.Log(false);
        }

    }
}