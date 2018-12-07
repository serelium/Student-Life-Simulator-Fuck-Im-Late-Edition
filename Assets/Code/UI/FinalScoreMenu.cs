using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalScoreMenu : MonoBehaviour {

    public GameObject gradeResult;
    public TextMeshProUGUI attemptsText;
    private int grade;

	// Use this for initialization
	void Start () {

        grade = 0;

        if (GameController.homeworkPagesOwned == 10)
            grade = 5;

        else if (GameController.homeworkPagesOwned == 9)
            grade = 4;

        else if (GameController.homeworkPagesOwned == 8)
            grade = 3;

        else if (GameController.homeworkPagesOwned == 7)
            grade = 2;

        else if (GameController.homeworkPagesOwned == 6)
            grade = 1;

        else if (GameController.homeworkPagesOwned <= 5)
            grade = 0;

        gradeResult.GetComponent<Animator>().SetInteger("Grade", grade);
        attemptsText.text = GameController.numberOfTries.ToString();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void BackToMainMenu()
    {
        GameController.ResetStats();
        SceneManager.LoadScene(0);
    }
}
