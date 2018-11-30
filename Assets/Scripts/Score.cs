using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    public Player player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Animator>().SetInteger("Score", player.nbOfHomeworkPages);
	}
}
