using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class PlayerControlledMovement : MonoBehaviour
{   

    PlayerController controller;
    private float EPSILON = 0.001f;
    int pos = 0;
    private bool isJumping = false;
    public void OnMove(InputValue value)
    {
        var v = value.Get<Vector2>();
        if (!isJumping) {
            if (v[0] < 0 && pos >= 0) {
                transform.Translate(-4f, 0, 0);
                pos--;
            }
            if (v[0] > 0 && pos <= 0)
            {
                transform.Translate(4f, 0, 0);
                pos++;
            }
        }
    }
    [SerializeField] float jumpHeight = 5f;
    [SerializeField] float gravity = 10f;
    private float jumpSpeed;
    float currentVerticalSpeed = 0;
    float defaultVerticalPosition;

    void Start()
    {
        defaultVerticalPosition = transform.position.y;
        jumpSpeed = (float)System.Math.Pow(jumpHeight * 2 * gravity, 0.5);
    }
    void OnJump()
    {
        if (!isJumping) {
            isJumping = true;
            currentVerticalSpeed = jumpSpeed;
        }
    }

    void Update()
    {
        if (isJumping)
        {
            transform.Translate(0f, currentVerticalSpeed * Time.deltaTime, 0f);
            currentVerticalSpeed -= gravity * Time.deltaTime;
        }
        if (transform.position.y < defaultVerticalPosition + EPSILON)
        {
            transform.position = new Vector3(transform.position.x, defaultVerticalPosition, transform.position.z);
            isJumping = false;
        }
    }
}
