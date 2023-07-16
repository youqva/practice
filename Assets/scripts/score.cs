using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    private void Update()
    {
        scoreText.text = ((int)player.position.z / 2).ToString();
    }
}
