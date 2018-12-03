using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameController {

    public static int playerHealth;
    public static int homeworkPagesOwned;
    public static int numberOfTries;

    public static void ResetStats()
    {
        playerHealth = 4;
        homeworkPagesOwned = 0;
        numberOfTries = 0;
    }
}
