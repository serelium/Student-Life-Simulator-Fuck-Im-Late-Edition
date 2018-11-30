using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

    private int score;
    public Player player;

	// Use this for initialization
	void Start () {

        score = 0;
	}
	
	// Update is called once per frame
	void Update () {

        GetComponent<Animator>().SetInteger("Score", player.nbOfHomeworkPages);
	}
}
