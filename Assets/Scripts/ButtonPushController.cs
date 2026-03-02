using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonPushController : MonoBehaviour
{
    Button restartButton;
    void Start()
    {
        Canvas canvas = FindFirstObjectByType<Canvas>();
        restartButton = canvas.GetComponentInChildren<Button>(true);
        restartButton.onClick.AddListener(RestartGame);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartButton.gameObject.SetActive(false);
    }
}