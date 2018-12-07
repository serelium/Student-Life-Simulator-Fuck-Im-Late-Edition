using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    private bool stop;
    private float stopPosition;
	
	// Update is called once per frame
	void LateUpdate () {

        if(target != null && !stop)
        {

            transform.position = target.position + offset;

            if (transform.position.x < 0)
                transform.position += new Vector3(-transform.position.x, 0, 0);

            if (transform.position.y < 0 || transform.position.y > 0)
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }

        else if(stop && stopPosition > transform.position.x)
        {

            transform.position = target.position + offset;
            if (transform.position.y < 0 || transform.position.y > 0)
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }

    public void Stop(float positionX)
    {
        stopPosition = positionX;
        //transform.position = new Vector3(positionX, 0, transform.position.z);
        stop = true;
    }
}
