using UnityEngine;

public class TankPlayer : MonoBehaviour
{
    TankController controller;

    void Start()
    {
        controller = GetComponent<TankController>();
    }

    void Update()
    {
        controller.controls.movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        controller.SetLookPointControls(worldPosition);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            controller.Shoot();
        };
    }
}
