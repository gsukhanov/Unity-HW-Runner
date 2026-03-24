using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;

    public UnityEvent onDeath;

    float currentHealth;
    public float getHealth() {
        return currentHealth;
    }

    void Start()
    {
        Canvas canvas = FindFirstObjectByType<Canvas>();
        currentHealth = gameSettings.playerMaxHealth;
        onDeath.AddListener(Die);
        onDeath.AddListener(RemoveSpeedBuff);
        onDeath.AddListener(RemoveJumpBuff);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            onDeath.Invoke();
        }
    }


    float speedBuffRemainingTime = 0f;
    public bool speedIsBuffed = false;
    public void GetSpeedBuff()
    {
        speedBuffRemainingTime += gameSettings.powerupDuration;
        if (!speedIsBuffed) speedIsBuffed = true;
    }
    public void RemoveSpeedBuff()
    {
        speedIsBuffed = false;
        speedBuffRemainingTime = 0f;
    }
    public void GetHealthBuff()
    {
        currentHealth += gameSettings.healthBuffSize;
    }
    float jumpBuffRemainingTime = 0f;
    public bool jumpIsBuffed = false;
    public void GetJumpBuff()
    {
        jumpBuffRemainingTime += gameSettings.powerupDuration;
        if (!jumpIsBuffed) jumpIsBuffed = true;
    }
    public void RemoveJumpBuff()
    {
        jumpIsBuffed = false;
        jumpBuffRemainingTime = 0f;
    }

    public void Update()
    {
        if (speedBuffRemainingTime > 0f) {
            speedBuffRemainingTime -= Time.deltaTime;
            if (speedBuffRemainingTime <= 0f)
            {
                RemoveSpeedBuff();
            }    
        }
        if (jumpBuffRemainingTime > 0f) {
            speedBuffRemainingTime -= Time.deltaTime;
            if (jumpBuffRemainingTime <= 0f)
            {
                RemoveJumpBuff();
            }    
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

}
