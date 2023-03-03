using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class ActivateTeleportationRay : MonoBehaviour
{
    public GameObject rightTeleportation;

    public InputActionProperty rightActivate;

    //public XRRayInteractor leftRay;
    //public XRRayInteractor rightRay;

    void Update()
    {
        //bool isLeftRayHovering = leftRay.TryGetHitInfo(out Vector3 leftpos, out Vector3 leftNormal, out int leftNumber, out bool leftValid);
        //bool isRightRayHovering = rightRay.TryGetHitInfo(out Vector3 rightpos, out Vector3 rightNormal, out int rightNumber, out bool rightValid);

        //rightTeleportation.SetActive(!isRightRayHovering && rightActivate.action.ReadValue<float>() > 0.1f);
        rightTeleportation.SetActive(rightActivate.action.ReadValue<float>() > 0.1f);
    }
}
