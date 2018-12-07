using UnityEngine;
using System.Collections;

public class SpriteFitScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {

        float cameraHeight = 2 * Camera.main.orthographicSize;
        float cameraWidth = Camera.main.aspect * cameraHeight;

        var sr = GetComponent<SpriteRenderer>();

        transform.localScale = new Vector3(1, 1, 1);

        var width = sr.bounds.size.x;
        var height = sr.bounds.size.y;

        var worldScreenHeight = Camera.main.orthographicSize * 2.0;
        var worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3((float)worldScreenWidth / width, (float)worldScreenHeight / height, transform.localScale.z);
    }
	
	// Update is called once per frame
	void Update () {


    }
}
