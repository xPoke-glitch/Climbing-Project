using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbing : MonoBehaviour
{
    public bool IsClimbing { get; private set; }

    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private BoxCollider playerCollider;
    [SerializeField]
    private PlayerAnimation playerAnimation;
    [SerializeField]
    private PlayerJumping playerJumping;

    [SerializeField]
    private float frontRayLength;

    private bool _isFacingWall = false;

    public void EnterClimbingState()
    {
        if (IsClimbing)
            return;
        if (!_isFacingWall)
            return;
        if (playerJumping.IsRolling)
            return;

        Debug.Log("[PlayerClimbing EnterClimbingState] CLIMBING ENTERED");
        
        rb.useGravity = false;

        IsClimbing = true;
    }

    public void ExitClimbingState()
    {
        if (!IsClimbing)
            return;

        Debug.Log("[PlayerClimbing ExitClimbingState] CLIMBING EXITED");

        playerCollider.enabled = false;
        InputManager.Instance.CanMove = false;

        playerAnimation.PlayAnimationByName("ClimbingTop", ClimbingFinished,1.0f);
    }

    // Callback on climbing animation finished
    public void ClimbingFinished()
    {
        playerCollider.enabled = true;
        rb.useGravity = true;
        IsClimbing = false;
        InputManager.Instance.CanMove = true;
    }

    private void Update()
    {
        if (!playerJumping.IsRolling)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + new Vector3(0f, 0.5f, 0.0f), transform.forward, out hit, frontRayLength))
            {
                if (hit.collider.gameObject.tag.Equals("Wall"))
                {
                    _isFacingWall = true;
                }
                else
                {
                    _isFacingWall = false;
                }
            }
            else
            {
                _isFacingWall = false;
            }
            Debug.DrawRay(transform.position + new Vector3(0f, 0.5f, 0.0f), transform.forward * frontRayLength, Color.red);
        }
        else
        {
            _isFacingWall = false;
        }
        
        if(IsClimbing && rb.useGravity)
        {
            rb.useGravity = false;
        }
    }
}
