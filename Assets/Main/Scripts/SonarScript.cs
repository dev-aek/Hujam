using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SonarScript : MonoBehaviour
{
    public ParticleSystem sonar;
    public int targetId;
    public float scaleValue = 150f;
    public float waitTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interact")
        {
            //Debug.Log("Dedective");
            other.GetComponent<InteractiveObject>().AppareObject(targetId, waitTime);
        }
    }

    public void ActivatedSonar(int id)
    {
        targetId = id;
        sonar.Play();
        this.transform.DOScale(new Vector3(scaleValue, scaleValue, scaleValue), waitTime / 3).OnComplete(() => this.transform.localScale = Vector3.zero);
    }

}
