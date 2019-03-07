using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleLerper2 : MonoBehaviour
{
    public AudioClip audioclip;
    AudioSource audioSource;
    public GameObject flashlight;
    public GameObject corridor;
    public Vector3 minScale;
    public Vector3 maxScale;
    public Vector3 defaultScale;
    public bool repeatable;
    public float speed = 2f;
    public float duration = 5f;



    // Use this for initialization

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine("Repeat");
            audioSource.PlayOneShot(audioclip, 0.7F);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            flashlight.SetActive(false);
            StopCoroutine("Repeat");
        }



        float ScaleDuration = 5f;
            Vector3 afterTriggerScale = corridor.transform.localScale;
            Vector3 defaultScale = new Vector3(1, 1, 1);

 
            {

                corridor.transform.localScale = Vector3.Lerp(afterTriggerScale, defaultScale, ScaleDuration);
            }

        flashlight.SetActive(true);

    }

    IEnumerator Repeat()
    {
        minScale = new Vector3(0.5f, 0.5f, 1);
        Vector3 defaultScale = new Vector3(1, 1, 1);
        while (repeatable)
        {
            yield return RepeatLerp(defaultScale, maxScale, duration);
            yield return RepeatLerp(maxScale, minScale, duration);
            yield return RepeatLerp(minScale, defaultScale, duration);

        }
    }

    public IEnumerator RepeatLerp(Vector3 a, Vector3 b, float time)
    {

        float i = 0.0f;
        float rate = (1.0f / time) * speed;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            corridor.transform.localScale = Vector3.Lerp(a, b, i);
            yield return null;
        }
    }





}
