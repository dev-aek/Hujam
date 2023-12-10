using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Subtitels : MonoBehaviour
{
    TextMeshProUGUI tmPro;
    public string[] subtiteles;
    int vlu = 0;
    public AudioSource auido;

    private void Awake()
    {
        tmPro = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        StartCoroutine(TvOld1());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator TvOld()
    {
        if (vlu < subtiteles.Length)
        {
            tmPro.text = subtiteles[vlu];
            vlu++;
        }
        yield return new WaitForSeconds(3f);
        if (vlu < subtiteles.Length)
        {
            StartCoroutine(TvOld());

        }
        else
        {
            Debug.Log("Yeni sahne");
        }
    }

    public IEnumerator TvOld1()
    {
        auido.Play();
        yield return new WaitForSeconds(1f);

        StartCoroutine(TvOld());

    }
}
