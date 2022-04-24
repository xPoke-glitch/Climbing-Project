using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour
{
    [SerializeField]
    private PlayerClimbing playerClimbing;
    [SerializeField]
    private PlayerJumping playerJumping;
    
    private Rigidbody _rb;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _animator.SetBool("IsMoving", InputManager.Instance.IsMoving);
        _animator.SetFloat("MoveDirectionX", InputManager.Instance.MoveDirection.x);
        _animator.SetFloat("MoveDirectionY", InputManager.Instance.MoveDirection.y);
        _animator.SetBool("IsRunning", InputManager.Instance.IsRunning);
        _animator.SetBool("IsClimbing", playerClimbing.IsClimbing);
        _animator.SetBool("IsGrounded", playerJumping.IsGrounded);

        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Falling To Roll"))
        {
            playerJumping.IsRolling = true;
            if (InputManager.Instance.CanMove)
            {
                StartCoroutine(COWaitAnimationEnd(_animator.GetCurrentAnimatorStateInfo(0).length-0.2f, () => {
                    _rb.useGravity = true;
                    InputManager.Instance.CanMove = true;
                    playerJumping.IsRolling = false;
                }));
            }
            _rb.useGravity = false;
            InputManager.Instance.CanMove = false;   
        }
    }

    public void PlayAnimationByName(string name, Action OnAnimationCompleted, float delay = 0.0f)
    {
        _animator.Play("Base Layer." + name);
        StartCoroutine(COWaitAnimationEnd(_animator.GetCurrentAnimatorStateInfo(0).length + delay, OnAnimationCompleted));
    }

    private IEnumerator COWaitAnimationEnd(float delay, Action Callback)
    {
        yield return new WaitForSeconds(delay);
        Callback?.Invoke();
    }
}
