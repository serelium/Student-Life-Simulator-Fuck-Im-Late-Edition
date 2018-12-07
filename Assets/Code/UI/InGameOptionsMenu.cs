using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class InGameOptionsMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }

    public void QuitToMainMenu()
    {
        GameController.ResetStats();
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
