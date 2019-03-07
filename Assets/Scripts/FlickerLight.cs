using UnityEngine;
using System.Collections;

public class FlickerLight : MonoBehaviour
{

    public GameObject Lights;
    public GameObject Lights2;
    public float timer;

    void Start()
    {
        StartCoroutine(FlickeringLight());
    }

    IEnumerator FlickeringLight()
    {
        Lights.SetActive(true);
        Lights2.SetActive(true);
        timer = Random.Range(0.1f, 1);
        yield return new WaitForSeconds(timer);
        Lights.SetActive(false);
        Lights2.SetActive(false);
        timer = Random.Range(0.1f, 1);
        yield return new WaitForSeconds(timer);
        StartCoroutine(FlickeringLight());
    }
}