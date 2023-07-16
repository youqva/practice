using UnityEngine;
using TMPro;

public class button_losep : MonoBehaviour
{

    public TextMeshProUGUI buttonText;

   
    public Color originalColor;

    
    public Color hoverColor;

   
    private void Start()
    {
        buttonText.color = originalColor;
    }

    public void OnMouseEnter()
    {
        buttonText.color = hoverColor;
    }

    public void OnMouseExit()
    {
        buttonText.color = originalColor;
    }
}