using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoader : MonoBehaviour
{
    public GameObject[] mapParts;
    GameObject randomMap;
    int index;

    public GameObject firstSection;
    public Vector3 offset;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Entered"))
        {
            LoadNexPart();
        }
    }

    public void LoadNexPart()
    {
        index = Random.Range(0, mapParts.Length);
        randomMap = mapParts[index];

        Vector3 nextPosition = firstSection.transform.position + offset;
        firstSection = Instantiate(randomMap, nextPosition, Quaternion.Euler(0, 0, 0));
    }
}
