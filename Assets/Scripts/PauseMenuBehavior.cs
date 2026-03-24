using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuBehavior : MonoBehaviour
{
    private PlayerInput playerInput;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] Button continueButton;
    [SerializeField] Button restartButton;
    [SerializeField] Button mainMenuButton;
    
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerInput = player.GetComponent<PlayerInput>();
        player.GetComponent<PlayerController>().onDeath.AddListener(Die);
        continueButton.onClick.AddListener(Unpause);
        restartButton.onClick.AddListener(Restart);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        PauseMenu.SetActive(false);
    }

    bool isPaused = false;
    bool dead = false;
    public void OnPause()
    {
        if (!dead) {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
    }



    void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Unpause()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }

    void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    void Die()
    {
        dead = true;
    }
}
