using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f; // environment moving speed

    void Update()
    {
        if (GlobalManager.Instance.canMoveEnvironment)
        {
            // Calculate the direction from the environment to the player along the Z-axis only
            Vector3 direction = new Vector3(0f, 0f, -1f);

            // Move the environment towards the player along the Z-axis only
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}



