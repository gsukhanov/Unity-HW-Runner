using UnityEngine;

public class LevelForwardMovement : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    float speed;
    float delta;
    void Start()
    {
        speed = gameSettings.startingSpeed;
        delta = (gameSettings.maxSpeed - gameSettings.startingSpeed) / (gameSettings.maxSpeedReachTime / Time.deltaTime);
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (speed < gameSettings.maxSpeed) speed += delta;
        else speed = gameSettings.maxSpeed;
    }
}
