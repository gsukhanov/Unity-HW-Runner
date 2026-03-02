using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    float speed = 1f;
    bool slowing = false;
    bool halt = false;
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Shade");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
        if (!halt) {
            if (speed < 10) speed *= 1.0007f;
            else if (Vector3.Distance(transform.position, player.transform.position) > 9f)
            {
                if (slowing) speed *= 0.9997f;
                else
                {
                    speed *= 1.0007f;
                    if (speed > 18f) slowing = true;
                }
            }
            else {
                halt = true;
                speed = 10;
            }
        } 
    }
}
