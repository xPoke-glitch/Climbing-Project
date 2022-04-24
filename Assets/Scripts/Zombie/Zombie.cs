using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float walkAcceleration;
    [SerializeField]
    private float walkRange;
    [SerializeField]
    private int layerMask = -1;

    private StateMachine _stateMachine;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _stateMachine = new StateMachine();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        var wander = new Wander(_agent, walkRange, layerMask, walkSpeed, walkAcceleration);

        _stateMachine.SetState(wander);
    }

    private void Update()
    {
        _stateMachine.Tick();
    }
}
