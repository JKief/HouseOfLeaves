using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLerper : MonoBehaviour
{
    public AudioClip audioclip;
    AudioSource audioSource;
    public GameObject corridor;
    public float Rotation_Speed;
    public float Rotation_Friction;
    public float Rotation_x;
    public float Rotation_y;
    public float Rotation_z;
    private bool isLerp = false;
    //The smaller the value, the more Friction there is. [Keep this at 1 unless you know what you are doing].


    public float Rotation_Smoothness;
    //Believe it or not, adjusting this before anything else is the best way to go.

    //private float Resulting_Value_from_Input; 
    private Quaternion Quaternion_Rotate_From;
    private Quaternion Quaternion_Rotate_To;

    // Use this for initialization 
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame 
    void Update()
    {
        //Resulting_Value_from_Input += Input.GetAxis ("Horizontal") * Rotation_Speed * Rotation_Friction;
        //You can also use "Mouse X" 

        if (isLerp == true)
        {
            
            Quaternion_Rotate_From = corridor.transform.rotation;
            Quaternion_Rotate_To = Quaternion.Euler(Rotation_x, Rotation_y, Rotation_z);
            corridor.transform.rotation = Quaternion.Lerp(Quaternion_Rotate_From, Quaternion_Rotate_To, Time.deltaTime * Rotation_Smoothness);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isLerp = true;
            audioSource.PlayOneShot(audioclip, 0.7F);
        }

       

    }
}



