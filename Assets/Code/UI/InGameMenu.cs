using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour {
     
    public GameObject inGameOptionsMenu;
    public Button pausePlayButton;
    public AudioMixer audioMixer;
    public EventSystem eventSystem;
    private bool gamePaused;
    private bool pausingGame;
    private bool fadeScreenNow;
    private float fadeScreenTime;
    private float fadeScreenDuration;

    // Use this for initialization
    void Start () {

        gamePaused = false;
        fadeScreenDuration = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {

        if (fadeScreenNow)
        {
            float startValue = 0;
            float endValue = 0.2f;
            float progress = Time.realtimeSinceStartup - fadeScreenTime;
            float alpha = pausingGame ? Mathf.Lerp(startValue, endValue, progress / fadeScreenDuration) : endValue - Mathf.Lerp(startValue, endValue, progress / fadeScreenDuration);

            GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, alpha);

            if (fadeScreenDuration < progress)
            {
                fadeScreenNow = false;
            }
        }
    }

    public void PauseOrPlay()
    {
        if (gamePaused)
            Play();

        else
            Pause();
    }

    private void Play()
    {
        Time.timeScale = 1f;
        pausePlayButton.GetComponent<Animator>().SetBool("Paused", false);
        pausingGame = false;
        gamePaused = false;
        //GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0);

        float volume;
        audioMixer.GetFloat("Volume", out volume);
        audioMixer.SetFloat("Volume", volume + 10);

        fadeScreenNow = true;
        fadeScreenTime = Time.realtimeSinceStartup;
        eventSystem.SetSelectedGameObject(null);
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        pausePlayButton.GetComponent<Animator>().SetBool("Paused", true);
        pausingGame = true;
        gamePaused = true;
        //GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.2f);

        float volume;
        audioMixer.GetFloat("Volume", out volume);
        audioMixer.SetFloat("Volume", volume - 10);

        fadeScreenNow = true;
        fadeScreenTime = Time.realtimeSinceStartup;
        eventSystem.SetSelectedGameObject(null);
    }

    public void OpenOptionsMenu()
    {
        Pause();
        //gameObject.SetActive(false);
    }
}
