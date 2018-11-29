using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
	
	// Update is called once per frame
	void LateUpdate () {

        if(target != null)
        {

            transform.position = target.position + offset;

            if (transform.position.x < 0)
                transform.position += new Vector3(-transform.position.x, 0, 0);
            if (transform.position.x > 500)
                transform.position = new Vector3(200, 0, transform.position.z);

            if (transform.position.y < 0 || transform.position.y > 0)
                transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
}
