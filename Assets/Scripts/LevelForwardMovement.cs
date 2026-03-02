using UnityEngine;

public class LevelForwardMovement : MonoBehaviour
{
    float speed = 1f;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (speed < 10) speed += 0.004f;
        else speed = 10;
    }
}
