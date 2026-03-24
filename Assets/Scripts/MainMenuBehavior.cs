using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBehavior : MonoBehaviour
{
    [SerializeField] Button startButton;
    [SerializeField] Button exitButton;
    [SerializeField] TMP_Text highScore;
    void Start()
    {
        highScore.text = "Рекорд: " + PlayerPrefs.GetInt("High Score", 0);
        startButton.onClick.AddListener(RunGame);
        exitButton.onClick.AddListener(Exit);
    }

    void RunGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    void Exit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
