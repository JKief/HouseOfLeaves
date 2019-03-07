using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_OnTrigger : MonoBehaviour {

    public GameObject corridor;
    public float speed = 1f;

    public void OnTriggerStay()
    {
        corridor.transform.Rotate(0, 0, speed);
    }
    // Update is called once per frame
    void Update () {
        
    }
}
