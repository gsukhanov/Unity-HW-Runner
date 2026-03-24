using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;
    private float speed;
    GameObject shade;
    PlayerController playerController;

    bool move = true;

    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        shade = GameObject.FindGameObjectWithTag("Shade");
        speed = gameSettings.startingSpeed;
    }

    float waitTime = 1f;
    void Update()
    {
        // DEPRECATED BEHAVIOR:
        // _______________________________________________________________________________________________________________________________
        // float maxSpeed = gameSettings.maxSpeed * (playerController.speedIsBuffed ? gameSettings.speedBuffScale : 1f);
        // exponent = (float)System.Math.Pow(maxSpeed / gameSettings.startingSpeed, 1 / (gameSettings.maxSpeedReachTime / Time.deltaTime));
        // transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        // if (!halt) {
        //     if (speed < maxSpeed) speed *= exponent;
        //     else if (Vector3.Distance(transform.position, shade.transform.position) > 9f)
        //     {
        //         if (slowing) speed *= 1 / exponent;
        //         else
        //         {
        //             speed *= exponent;
        //             if (speed > 1.8f * maxSpeed) slowing = true;
        //         }
        //     }
        //     else {
        //         halt = true;
        //         speed = maxSpeed;
        //     }
        // } 
        // _________________________________________________________________________________________________________________________________
        if (waitTime > 0) {
            waitTime -= Time.deltaTime;
        }
        else if (waitTime > -1f || waitTime < -2f)
        {
            float maxSpeed = gameSettings.maxSpeed * (playerController.speedIsBuffed ? gameSettings.speedBuffScale : 1f);
            float delta = (maxSpeed - gameSettings.startingSpeed) / (gameSettings.maxSpeedReachTime / Time.deltaTime);
            if (move) {
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
                if (speed < maxSpeed) speed += delta;
                else speed = maxSpeed;
            }
            if (waitTime > -1f) waitTime -= Time.deltaTime;
        }
        else if (waitTime > -2f)
        {
            float maxSpeed = gameSettings.maxSpeed * (playerController.speedIsBuffed ? gameSettings.speedBuffScale : 1f) * 1.8f;
            float delta = (maxSpeed - gameSettings.startingSpeed) / (gameSettings.maxSpeedReachTime / Time.deltaTime);
            if (move) {
                transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
                if (speed < maxSpeed) speed += delta;
                else speed = maxSpeed;
            }
            waitTime -= Time.deltaTime;
        }
    }
    // Following fields are deprecated:
    // private float exponent;
    // bool slowing = false;
    // bool halt = false;

}