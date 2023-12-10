using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class RotateManager : MonoBehaviour
{
    public int spped = 10;
    public int waitTime = 7;
    public GameObject cam1;
    public GameObject subtitle;
    public Image voice;
    public Image rbt;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TvOld());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * spped, Space.World);
    }

    public void FlyThis()
    {
        spped = 200;
        transform.DOMove(new Vector3(10, 40, -10), waitTime).OnComplete(() =>StartCoroutine(NewScene()));

    }

    public void PlayTV()
    {

    }

    public IEnumerator TvOld()
    {
        voice.color = new Color32(255, 255, 255, 130);
        rbt.color = new Color32(0, 79, 43, 130);
        yield return new WaitForSeconds(0.1f);
        voice.color = new Color32(0, 79, 43, 130);
        rbt.color = new Color32(255, 255, 255, 130);
        StartCoroutine(TvOld2());
    }
    public IEnumerator TvOld2()
    {
        voice.color = new Color32(0, 79, 43, 130);
        rbt.color = new Color32(255, 255, 255, 130);

        yield return new WaitForSeconds(0.1f);
        voice.color = new Color32(255, 255, 255, 130);
        rbt.color = new Color32(0, 79, 43, 130);
        StartCoroutine(TvOld());
    }
    public IEnumerator NewScene()
    {

        cam1.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        subtitle.SetActive(true);
    }
}
