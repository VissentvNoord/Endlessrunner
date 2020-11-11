using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDestroyer : MonoBehaviour
{
    private GameObject playerTransform;
    private float distance;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void Update()
    {
        distance = Vector3.Distance(transform.position, playerTransform.transform.position);

        if(distance > 70)
        {
            Destroy(gameObject);
        }
    }
}
