using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float runningSpeed;
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private PlayerClimbing playerClimbing;

    void Update()
    {
        if (InputManager.Instance.CanMove)
        {
            float speed = walkSpeed;
            if (InputManager.Instance.IsRunning && !playerClimbing.IsClimbing)
            {
                speed = runningSpeed;
            }
            else
            {
                speed = walkSpeed;
            }

            if (!playerClimbing.IsClimbing)
            {
                transform.position += Time.deltaTime * speed * InputManager.Instance.MoveDirection.y * transform.forward;
                transform.Rotate(new Vector3(0.0f, InputManager.Instance.MoveDirection.x, 0.0f) * rotationSpeed * Time.deltaTime);
            }

            if (playerClimbing.IsClimbing)
            {
                transform.position += Time.deltaTime * speed * InputManager.Instance.MoveDirection.y * transform.up;
            }
        }
    }
}
