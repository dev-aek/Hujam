using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Subtitels : MonoBehaviour
{
    TextMeshProUGUI tmPro;
    public string[] subtiteles;
    int vlu = 0;
    public AudioSource auido;
    public AudioSource auido2;
    bool isAudioOut;

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
        if (isAudioOut)
        {
            auido2.volume -= Time.deltaTime/25;
        }
    }

    public IEnumerator TvOld()
    {
        isAudioOut = true;
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
            SceneManager.LoadScene("Presents");
        }
    }

    public IEnumerator TvOld1()
    {
        auido.Play();
        yield return new WaitForSeconds(1f);

        StartCoroutine(TvOld());

    }
}
