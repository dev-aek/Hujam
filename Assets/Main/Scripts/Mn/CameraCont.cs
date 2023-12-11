using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraCont : MonoBehaviour
{
    public GameObject cam;
    public GameObject ekObject;
    public GameObject target;
    public float waitTime;
    public GameObject uiElement;

    void Start()
    {
        StartCoroutine(Wtfscnd()) ;
        transform.DOMove(target.transform.position, waitTime).OnComplete(() => CamAction());
        if (cam == null)
        {
            ekObject.SetActive(true);
        }
    }

    void Update()
    {
        
    }

    public void CamAction()
    {
        uiElement.SetActive(false);
        if (cam !=null)
        {
            cam.SetActive(true);
            gameObject.SetActive(false);
        }

        

    }

    IEnumerator Wtfscnd()
    {
        yield return new WaitForSeconds(2f);
        uiElement.SetActive(true);

    }
}
