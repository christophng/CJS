using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnvCollide : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Normal: " + collision.contacts[0].normal);

        // If y != 0, then its a top surface contact
        if (collision.contacts[0].normal.y != 0.0f) {

            Debug.Log("TOP SURFACE DETECTED");
        }

        // Else, its a side contact

        else {
            Debug.Log("SIDE SURFACE DETECTED");
            GlobalManager.Instance.canMoveEnvironment = false;
            GlobalManager.Instance.resetMenu.SetActive(true);

            Time.timeScale = 0f; // Freeze if game stopping collision
        }

        // {
        //     canMove = true;
        // }
    }
}



