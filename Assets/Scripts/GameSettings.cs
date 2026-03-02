using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings", menuName = "Game Settings")]
public class GameSettings : ScriptableObject
{
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float gravity = 10f;
    [Tooltip("Starting speed of forward movement")]
    [SerializeField] float startingSpeed = 1f;
    [Tooltip("Maximum speed of forward movement")]
    [SerializeField] float maxSpeed = 1f;
    [Tooltip("Time to reach maximum speed")]
    [SerializeField] float maxSpeedReachTime = 1f;
    [Tooltip("Average obstacle damage (real would fluctuate from 50% to 200% of that value)")]
    [SerializeField] float mediumObstacleDamage = 10f;
}
