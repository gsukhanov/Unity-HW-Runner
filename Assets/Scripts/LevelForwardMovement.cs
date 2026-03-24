using NUnit.Framework;
using UnityEngine;

public class LevelForwardMovement : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    float speed;
    float delta;
    bool move = true;
    PlayerController playerController;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.onDeath.AddListener(Stop);
        speed = gameSettings.startingSpeed;
    }
    void Update()
    {
        float maxSpeed = gameSettings.maxSpeed * (playerController.speedIsBuffed ? gameSettings.speedBuffScale : 1f);
        delta = (maxSpeed - gameSettings.startingSpeed) / (gameSettings.maxSpeedReachTime / Time.deltaTime);
        if (move) {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
            if (speed < maxSpeed) speed += delta;
            else speed = maxSpeed;
        }
    }

    void Stop()
    {
        move = false;
    }

}
