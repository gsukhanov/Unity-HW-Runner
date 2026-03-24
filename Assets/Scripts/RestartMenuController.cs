using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class RestartMenuController : MonoBehaviour
{
    GameObject player;
    GameObject shade;
    [SerializeField] Button restartButton;
    [SerializeField] Button exitButton;
    [SerializeField] GameObject UI;
    [SerializeField] TMP_Text currentScoreText;
    [SerializeField] TMP_Text highScoreText;
    void Start()
    {
        Time.timeScale = 1f;
        shade = GameObject.FindGameObjectWithTag("Shade");
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().onDeath.AddListener(Activate);
        restartButton.onClick.AddListener(RestartGame);
        exitButton.onClick.AddListener(ExitToMainMenu);
        UI.SetActive(false);
        Cursor.visible = false;
    }

    public void Activate()
    {
        UI.SetActive(true);
        currentScoreText.text = "Итоговый счёт: " + (int)shade.transform.position.z;
        highScoreText.text = "Рекорд: " + PlayerPrefs.GetInt("High Score", 0);
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}