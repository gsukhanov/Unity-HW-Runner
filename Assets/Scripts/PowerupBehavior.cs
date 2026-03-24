using System;
using UnityEngine;

public class PowerupBehavior : MonoBehaviour
{
    enum PowerupType {SPEED, HEALTH, JUMP};
    [SerializeField] PowerupType type;


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
            if (type == PowerupType.SPEED)
            {
                playerController.GetSpeedBuff();
            }
            if (type == PowerupType.HEALTH)
            {
                playerController.GetHealthBuff();
            }
            if (type == PowerupType.JUMP)
            {
                playerController.GetJumpBuff();
            }
        }
        Destroy(gameObject);
    }
}