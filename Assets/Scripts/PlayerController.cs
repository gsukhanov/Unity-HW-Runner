using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    Button restartButton;

    float currentHealth = 100;
    public float getHealth() {
        return currentHealth;
    }

    void Start()
    {
        Canvas canvas = FindFirstObjectByType<Canvas>();
        restartButton = canvas.GetComponentInChildren<Button>(true);
        currentHealth = gameSettings.playerMaxHealth;
    }

    // Update is called once per frame

    public void OnTriggerEnter(Collider collider)
    {
        GameObject obstacle = collider.gameObject;
        currentHealth -= obstacle.GetComponent<ObstacleBehaviour>().getDamage();
        Destroy(obstacle);
        if (currentHealth < 0)
        {
            restartButton.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

}
