using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public playermovement movemnt;
    public float levelRestartDelay = 2f;
    public GameObject Panellose;
    public TextMeshProUGUI recordText;
    public AudioClip musicGame;
    private AudioSource soundPlayer;

    public void Start()
    {
        Panellose.SetActive(false);
        soundPlayer = GetComponent<AudioSource>();
        if (soundPlayer != null && musicGame != null)
        {
            soundPlayer.PlayOneShot(musicGame);
        }
    }

   /* public void musicOff()
    {
        soundPlayer.Pause();
    }*/

    public void EndGame() { 
        movemnt.enabled = false;
        soundPlayer.Pause();
        int lastRunScore = PlayerPrefs.GetInt("lastRunScore");
        int recordScore = PlayerPrefs.GetInt("recordScore");

        if (lastRunScore > recordScore)
        {
            recordScore = lastRunScore;
            PlayerPrefs.SetInt("recordScore", recordScore);
            recordText.text = recordScore.ToString();
        }
        else
        {
            recordText.text = recordScore.ToString();
        }
        Panellose.SetActive(true);
        //Invoke("RestartLevel", levelRestartDelay);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("level");
    }

    public void BactToMenu()
    {
        SceneManager.LoadScene("menu");
    }
}
