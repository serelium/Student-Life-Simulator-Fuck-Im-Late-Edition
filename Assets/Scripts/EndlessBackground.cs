using UnityEngine;
using System.Collections;

public class EndlessBackground : MonoBehaviour {

    public GameObject[] backgrounds;
    public float cameraWidth;
    public float speed;
    public Collider2D floor;
    private int index;

	// Use this for initialization
	void Start () {

        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (index > backgrounds.Length - 1) 
            index = 0;

        if (Camera.main.transform.position.x > 0 && Camera.main.transform.position.x > backgrounds[index].transform.position.x + cameraWidth) {

            backgrounds[index].transform.position += new Vector3(backgrounds.Length * cameraWidth, 0, 0);
            index++;

            if(floor != null)
                floor.transform.position += new Vector3(cameraWidth, 0, 0);

        }

        if (speed > 0)
            transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
