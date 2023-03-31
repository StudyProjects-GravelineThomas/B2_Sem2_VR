using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{
    public bool open;
    public float i;
    public float t;
    public GameObject door;
    public void OpenTheDoor()
    {
        open = true;
        t = 0.25f;
    }

    public void Update()
    {
        if(open)
        {
            i -= 0.1f;
        }
        else
        {
            i += 0.1f;
        }

        i = Mathf.Clamp(i, -1, 0);
        door.transform.localPosition = new Vector3(door.transform.localPosition.x, Mathf.Sin(i), door.transform.localPosition.z);

        t -= Time.deltaTime;
        if(t <= 0)
        {
            open= false;
        }
    }
}
