using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    public bool IsGrounded { get; private set; }
    public bool IsRolling { get; set; }

    [SerializeField]
    private PlayerClimbing climbing;
    [SerializeField]
    private float underRayLength;
   
    private void Awake()
    {
        IsGrounded = true;
        IsRolling = false;
    }

    private void Update()
    {
        if (!climbing.IsClimbing)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + new Vector3(0f, 0.5f, 0.2f), transform.up * -1, out hit, underRayLength))
            {
                if (hit.collider.gameObject.tag.Equals("Floor") || hit.collider.gameObject.tag.Equals("Wall"))
                {
                    IsGrounded = true;
                }
                else
                {
                    IsGrounded = false;
                }
            }
            else
            {
                IsGrounded = false;
            }
            Debug.DrawRay(transform.position + new Vector3(0f, 0.5f, 0.2f), transform.up * -1 * underRayLength, Color.blue);
        }
        if (climbing.IsClimbing)
        {
            IsGrounded = true;
        }
    }
}
