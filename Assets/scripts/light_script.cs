using UnityEngine.SceneManagement;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "level")
        {
            gameObject.SetActive(true); // активируем свет на сцене с игрой
        }
        else if (SceneManager.GetActiveScene().name == "menu")
        {
            gameObject.SetActive(false); // деактивируем свет на сцене меню
        }
    }
}