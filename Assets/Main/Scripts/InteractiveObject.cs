using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public int objectId;
    public ParticleSystem sonar;
    public float waitTime = 10f;

    public void AppareObject(int id)
    {
        if (objectId == id)
        {
            StartCoroutine(AppareObjectWait());
        }
    }

    public IEnumerator AppareObjectWait()
    {
        sonar.Play();
        yield return new WaitForSeconds(waitTime);
        sonar.Stop();


    }
}
