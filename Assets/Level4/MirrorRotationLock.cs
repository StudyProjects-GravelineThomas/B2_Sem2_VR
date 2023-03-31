using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotationLock : MonoBehaviour
{
    void FixedUpdate()
    {
        this.gameObject.transform.Rotate(new Vector3(1, 0, 0), -this.gameObject.transform.rotation.x * 10);
        this.gameObject.transform.Rotate(new Vector3(0, 0, 1), -this.gameObject.transform.rotation.z * 10);


    }
}
