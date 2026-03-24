using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControlledMovement : MonoBehaviour
{   
    [SerializeField] GameSettings gameSettings;
    private float EPSILON = 0.001f;
    int pos = 0;
    private bool isJumping = false;

    PlayerController playerController;
    public void OnMove(InputValue value)
    {
        var v = value.Get<Vector2>();
        if (!isJumping || playerController.jumpIsBuffed) {
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
    private float jumpSpeed;
    float currentVerticalSpeed = 0;
    float defaultVerticalPosition;

    void Start()
    {
        playerController = gameObject.GetComponent<PlayerController>();
        defaultVerticalPosition = transform.position.y;
    }
    public void OnJump()
    {
        if (!isJumping) {
            isJumping = true;        {
            
            float jumpParam = (gameSettings.jumpHeight + (playerController.jumpIsBuffed ? gameSettings.jumpBuffHeight : 0)) * 2 * gameSettings.gravity;
            
            jumpSpeed = (float)System.Math.Pow(jumpParam, 0.5);
        }
            currentVerticalSpeed = jumpSpeed;
        }
    }

    void Update()
    {
        if (isJumping)
        {
            transform.Translate(0f, currentVerticalSpeed * Time.deltaTime, 0f);
            currentVerticalSpeed -= gameSettings.gravity * Time.deltaTime;
        }
        if (transform.position.y < defaultVerticalPosition + EPSILON)
        {
            transform.position = new Vector3(transform.position.x, defaultVerticalPosition, transform.position.z);
            isJumping = false;
        }
    }
}
