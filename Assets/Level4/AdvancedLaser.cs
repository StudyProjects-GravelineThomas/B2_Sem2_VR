using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedLaser : MonoBehaviour
{

    public int MaxBounces = 5;
    public LineRenderer lr;
    public Transform startpoint;

    public void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, startpoint.position);
        lr.positionCount = MaxBounces + 1;
    }


    public void Update()
    {
        CastLaser(transform.position, -transform.forward);
    }

    public void CastLaser(Vector3 position, Vector3 direction)
    {
        lr.SetPosition(0, startpoint.position);

        for(int i = 0; i < MaxBounces; i++)
        {
            Ray ray = new Ray(position, direction);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 300, 1)) 
            {
                Debug.Log("Raycast moment");

                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                lr.SetPosition(i+1, hit.point);
            }
        }
    }
}
