using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedLaser : MonoBehaviour
{

    public int MaxBounces = 5;
    public int Y;

    public bool Finish;

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
        lr.positionCount = MaxBounces + 1;

        CastLaser(transform.position, transform.forward);
    }

    public void CastLaser(Vector3 position, Vector3 direction)
    {
        for(int i = 0; i < MaxBounces; i++)
        {
            Ray ray = new Ray(position, direction);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 300, 1)) 
            {
                Debug.Log("Raycast moment");
                position = hit.point;

                if (hit.transform.tag == "Mirror")
                {
                    direction = Vector3.Reflect(direction, hit.normal);
                }
                else
                {
                    while(i < MaxBounces)
                    {
                        lr.SetPosition(i + 1, hit.point);
                        i++;
                    }
                }

                if(hit.transform.tag == "Finish")
                {
                    Finish = true;
                }
                else
                {
                    Finish = false;
                }

                Y = MaxBounces - i;
                while(Y > 0)
                {
                    Y--;

                    lr.SetPosition(MaxBounces - Y, hit.point);
                }
            }
        }
    }
}
