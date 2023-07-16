using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image buttonImage;

    private Color originalColor;

    public Color hoverColor;

    private void Start()
    {
        buttonImage = GetComponent<Image>();

        originalColor = buttonImage.color;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.color = originalColor;
    }
}