using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFX : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem smokeVFX;

    public void PlaySmokeVFX()
    {
        smokeVFX.Play();
    }
}
