using UnityEngine.SceneManagement;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "level")
        {
            gameObject.SetActive(true); // ���������� ���� �� ����� � �����
        }
        else if (SceneManager.GetActiveScene().name == "menu")
        {
            gameObject.SetActive(false); // ������������ ���� �� ����� ����
        }
    }
}