using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScripts : MonoBehaviour
{
    public GameObject[] finalObjects;
    public float waitPerObject;
    public int vlu;
    public bool timeLapse;
    public GameObject lightObject;
    float timeSSpeed = 4f;
    public AudioSource music;
    public GameObject[] cams;
    public GameObject[] cine2;
    public GameObject puzzle;



    private void Start()
    {
      //  SetGameFinal();
        music.Play();
    }
    private void Update()
    {
        if (timeLapse)
        {
            if (lightObject.transform.rotation.x < 180 && lightObject.transform.rotation.x > -20)
            {
                lightObject.transform.Rotate(Vector3.left * Time.deltaTime * timeSSpeed, Space.World);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (UIManager.Instance.isGameOver)
            {
                UIManager.Instance.quests[4].questCurrentProgress++;
                UIManager.Instance.CheckQuest();
                puzzle.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //cams[0].SetActive(false);
            }


        }
    }

    public void SetGameFinal()
    {
        UIManager.Instance.qPanel.SetActive(false);
        cams[1].SetActive(true);
        cams[0].SetActive(false);
        music.Stop();
        music.Play();
        music.volume = 0.7f;


        timeLapse = true;
        StartCoroutine(TvOld());
    }

    public IEnumerator TvOld()
    {
        if (vlu < finalObjects.Length)
        {
            finalObjects[vlu].SetActive(true);
            vlu++;
        }
        yield return new WaitForSeconds(3f);
        if (vlu < finalObjects.Length)
        {
            StartCoroutine(TvOld());

        }
        else
        {
           // timeLapse = false ;
            Debug.Log("Bitiþþþ");
            StartCoroutine(Cine2());
        }
    }
    public IEnumerator Cine2()
    {
        timeSSpeed *= 8;
        for (int i = 0; i < cine2.Length; i++)
        {
            cine2[i].SetActive(true);
        }
        cine2[4].SetActive(false);
        cine2[5].SetActive(false);

        yield return new WaitForSeconds(7f);
        timeSSpeed = 10f;
        cine2[0].SetActive(false);
        cine2[1].SetActive(false);
        cams[2].SetActive(true);
        cams[1].SetActive(false);
        StartCoroutine(Cine3());
    }

    public IEnumerator Cine3()
    {

        yield return new WaitForSeconds(9f);
        cine2[0].SetActive(true);
        cine2[4].SetActive(true);
        StartCoroutine(Cine4());
    }

    public IEnumerator Cine4()
    {

        yield return new WaitForSeconds(9f);
        cine2[5].SetActive(true);
        cine2[4].SetActive(false);
    }
}
