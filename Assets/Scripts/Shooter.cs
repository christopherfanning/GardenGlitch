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
    Animator animator;

    void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (IsAttackerInLane())
        {
            // Debug.Log("Fire away!");
            animator.SetBool("isAttacking", true);
        }
        else
        {
            // Debug.Log("Sit and wait");
            animator.SetBool("isAttacking", false);
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
