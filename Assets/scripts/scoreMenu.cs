using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoreMenu : MonoBehaviour
{
    public TextMeshProUGUI recordText;
    private void Start()
    {
        int recordScore = PlayerPrefs.GetInt("recordScore");
        recordText.text = recordScore.ToString();
    }

    public void ResetRecord()
    {
        PlayerPrefs.SetInt("recordScore", 0);
        int recordScore = PlayerPrefs.GetInt("recordScore");
        recordText.text = recordScore.ToString();
    }
}
