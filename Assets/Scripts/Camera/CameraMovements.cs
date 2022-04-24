using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField]
    private CinemachineFreeLook cinemachine;
    [SerializeField]
    private float cameraMovementMaxSpeed = 150.0f;
    [SerializeField]
    private float secondToCameraReset = 0.5f;

    private bool _doOnce = false;

    private void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        if (InputManager.Instance.IsMovingCamera)
        {
            cinemachine.m_XAxis.m_MaxSpeed = cameraMovementMaxSpeed;
            _doOnce = false;
        }
        else if(!_doOnce)
        {
            _doOnce = true;
            StartCoroutine(CoChangeValue(cinemachine.m_XAxis.Value, 0.0f, secondToCameraReset));
            cinemachine.m_XAxis.m_MaxSpeed = 0;
        }
    }

    private IEnumerator CoChangeValue(float start, float end, float duration)
    {
        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            cinemachine.m_XAxis.Value = Mathf.Lerp(start, end, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }
        cinemachine.m_XAxis.Value = end;
    }
}
