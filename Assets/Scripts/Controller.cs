using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField, Range(0f, 100f)] float moveForceAir = 10;
    [SerializeField, Range(0f, 100f)] float moveForceGround = 10;

    [SerializeField, Range(0f, 100f)] float jumpForce = 10;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D ballCollider;

    Vector2 moveDir = Vector2.zero;
    bool jump = false;

    void FixedUpdate()
    {
        Vector2 horizontalMove = Vector3.Project(moveDir, Vector2.right);

        bool isOnGround = ballCollider.IsTouchingLayers();

        if (jump && isOnGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        float moveForce = isOnGround ? moveForceGround : moveForceAir;

        rb.AddForce(horizontalMove * moveForce);
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        moveDir = ctx.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext ctx)
    {
        jump = ctx.performed;
    }
}
