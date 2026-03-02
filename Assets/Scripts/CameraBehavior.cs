using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    private float speed;
    private float exponent;
    bool slowing = false;
    bool halt = false;
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Shade");
        speed = gameSettings.startingSpeed;
        exponent = (float)System.Math.Pow(gameSettings.maxSpeed / gameSettings.startingSpeed, 1 / (gameSettings.maxSpeedReachTime / Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        if (!halt) {
            if (speed < gameSettings.maxSpeed) speed *= exponent;
            else if (Vector3.Distance(transform.position, player.transform.position) > 9f)
            {
                if (slowing) speed *= 1 / exponent;
                else
                {
                    speed *= exponent;
                    if (speed > 1.8f * gameSettings.maxSpeed) slowing = true;
                }
            }
            else {
                halt = true;
                speed = gameSettings.maxSpeed;
            }
        } 
    }
}
