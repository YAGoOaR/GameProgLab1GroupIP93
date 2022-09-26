using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] float moveForce = 1;
    [SerializeField] float torqueForce = 1;

    [SerializeField] Transform turret;
    [SerializeField] Transform hull;

    Gun gun;
    TankAnimator animator;

    Rigidbody2D rb;

    public struct ControlVariables
    {
        public Vector2 movement;
        public Vector2 lookDirection;
    }

    public ControlVariables controls = new ControlVariables();

    void Start()
    {
        rb = hull.GetComponent<Rigidbody2D>();
        animator = hull.GetComponent<TankAnimator>();
        gun = turret.GetComponentInChildren<Gun>();
    }

    void FixedUpdate()
    {
        UpdatePhysics();
    }

    void Update()
    {
        UpdateGraphics();
    }

    void UpdatePhysics()
    {
        Vector2 verticalMove = Vector2.up * controls.movement.y;

        Vector2 force = verticalMove * moveForce;
        rb.AddRelativeForce(force, ForceMode2D.Force);

        float torque = controls.movement.x * torqueForce;
        rb.AddTorque(-torque);
    }

    void UpdateGraphics()
    {
        turret.up = controls.lookDirection;
        animator.SwitchAnimation(controls.movement.magnitude > 0);
    }

    public void SetLookPointControls(Vector2 destination)
    {
        controls.lookDirection = destination - (Vector2)hull.position;
    }

    public void Shoot()
    {
        gun.Shoot();
    }
}
