using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public int objectId;
    public ParticleSystem sonar;
    public float waitTime = 10f;
    public GameObject info;
    public int uiId;
    public void AppareObject(int id, float waitT)
    {
        waitTime = waitT;
        if (objectId == id)
        {
            StartCoroutine(AppareObjectWait());
        }
    }

    public IEnumerator AppareObjectWait( )
    {
        sonar.Stop();
        sonar.Play();
        yield return new WaitForSeconds(waitTime);
        sonar.Stop();


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            info.gameObject.SetActive(true);
            sonar.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            info.gameObject.SetActive(false) ;
            sonar.Stop();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Player"))
            {
                UIManager.Instance.quests[objectId].questCurrentProgress++;
                UIManager.Instance.CheckQuest();
                
                Destroy(gameObject);
            }
        }

    }
}
