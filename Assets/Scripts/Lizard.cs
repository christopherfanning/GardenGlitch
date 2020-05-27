using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            // Call stuff from attacker script
            GetComponent<Attacker>().Attack(otherObject);
            // hole.Attack();

        }
    }
}
