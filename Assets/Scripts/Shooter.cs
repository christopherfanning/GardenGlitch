using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile, gun;
    // s GameObject gun = Transform child;
    AttackerSpawner[] spawners;
    AttackerSpawner myLaneSpawner;


    void Start()
    {
        SetLaneSpawner();
    }

    void Update()
    {
        if (IsAttackerInLane())
        {
            Debug.Log("Fire away!");
            // TODO Change animation state to shooting
        }
        else
        {
            Debug.Log("Sit and wait");
            // TODO change animation state to Idle. 
        }
    }


    void SetLaneSpawner()
    {
        spawners = FindObjectsOfType<AttackerSpawner>();
        foreach( AttackerSpawner spawner in spawners )
        {
            bool IsCloseEnough =
                (Mathf.Abs ( spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon );
            if ( IsCloseEnough )
            {
                myLaneSpawner  = spawner;
            }
        }
    }
    
    bool IsAttackerInLane()
    {
        if ( myLaneSpawner.transform.childCount <= 0 )
        {
            return false;
        }
        else 
        {
            return true;
        }
    }

    public void Fire()
    {
        Instantiate(projectile, gun.transform.position, transform.rotation);
    }
}
