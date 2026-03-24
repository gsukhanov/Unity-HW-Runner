using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class UIDisplay : MonoBehaviour
{
    GameObject shade;
    GameObject player;
    [SerializeField] public TMP_Text healthText;
    [SerializeField] public TMP_Text currentScoreText;
    [SerializeField] public TMP_Text highScoreText;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().onDeath.AddListener(SaveScore);
        shade = GameObject.FindGameObjectWithTag("Shade");
        highScore = PlayerPrefs.GetInt("High Score", 0);
    }
    int highScore;
    bool dead = false;
    void Update()
    {
        if (!dead) healthText.text = "Current Health: " + ((int)player.GetComponent<PlayerController>().getHealth()).ToString();
        else healthText.text = "Current Health: 0. You died!";
        int currentScore = (int)shade.transform.position.z;
        currentScoreText.text = "Current Score: " + currentScore.ToString();
        highScore = currentScore > highScore ? currentScore : highScore;
        highScoreText.text = "High Score: " + highScore.ToString();
    }

    void SaveScore()
    {
        dead = true;
        PlayerPrefs.SetInt("High Score", highScore);
    }
}
