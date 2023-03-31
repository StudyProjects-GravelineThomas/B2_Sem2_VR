using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorRotationLock : MonoBehaviour
{
    void FixedUpdate()
    {
        this.gameObject.transform.eulerAngles = new Vector3(0, this.gameObject.transform.eulerAngles.y, 0);
    }
}
