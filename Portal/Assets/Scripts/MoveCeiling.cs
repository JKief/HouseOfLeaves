using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCeiling : MonoBehaviour
{
    public GameObject wall;

    private Vector3 startPos;

    private Vector3 endPos;

    private float distance = 2.5f;

    private float lerpTime = 90f;

    private float currentlerpTime = 0;

    private bool keyhit = false;

    // Use this for initialization


    void Start()

    {
        startPos = wall.transform.position;
        endPos = wall.transform.position + Vector3.down * distance;

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            keyhit = true;
        }

        if (keyhit == true)
        {
            currentlerpTime += Time.deltaTime;
            if (currentlerpTime >= lerpTime)
            {
                currentlerpTime = lerpTime;
            }
        }

        float Perc = currentlerpTime / lerpTime;
        wall.transform.position = Vector3.Lerp(startPos, endPos, Perc);

    }

}
