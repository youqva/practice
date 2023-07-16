using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenu : MonoBehaviour
{

    public AudioClip menuOpenSound;
    private AudioSource soundPlayer;
    public AudioClip buttonSoundClip;
    private AudioSource audioSource;

    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
        if (soundPlayer != null && menuOpenSound != null)
        {
            soundPlayer.PlayOneShot(menuOpenSound);
        }
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = buttonSoundClip;
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(buttonSoundClip);
    }



    public void musicOff()
    {
        soundPlayer.Stop();

    }

    public void musicOn()
    {
        soundPlayer.PlayOneShot(menuOpenSound);
    }


    public void PlayGame()
    {
        SceneManager.LoadScene("level");
    }

    public void BactToMenu()
    {
        SceneManager.LoadScene("menu");
    }


    public void ExitGame()
    {
        Debug.Log("Game exit!");
        Application.Quit();
    }
}
