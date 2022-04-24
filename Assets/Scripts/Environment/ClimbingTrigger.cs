using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbingTrigger : MonoBehaviour
{
    [SerializeField]
    private bool isEnterTrigger;
    
    private void OnTriggerEnter(Collider other)
    {
        if (isEnterTrigger)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                other.gameObject.GetComponent<PlayerClimbing>().EnterClimbingState();
            }
        }
        else
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                other.gameObject.GetComponent<PlayerClimbing>().ExitClimbingState();
            }
        }
       
    }
}
