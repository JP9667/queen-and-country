using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sing UnityEngine.AI;

public class whaleControl : MonoBehaviour {
    public Transform[] Waypoints;
    public float Speed;
    public int curWayPoint;
    public bool doPatrol = true;
    public Vector3 Target;
    public Vector3 MoveDirection;
    public Vector3 Velocity;
    private Rigidbody whale;

    private void Start()
    {
        whale = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(curWayPoint < Waypoints.Length)
        {
            Target = Waypoints[curWayPoint].position;
            MoveDirection = Target - transform.position;
            //whale.transform.Rotate(0, -1, 0);
            Velocity = whale.velocity;
         
            if(MoveDirection.magnitude < 1)
            {
                curWayPoint++;
            }
            else
            {
                Velocity = MoveDirection.normalized * Speed;
            }
        }
        else
        {
            if(doPatrol)
            {
                curWayPoint = 0;
            }
            else
            {
                Velocity = Vector3.zero;
            }
        }
        whale.velocity = Velocity;
        transform.LookAt(Target);
    }
}

