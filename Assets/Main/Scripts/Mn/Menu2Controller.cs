using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu2Controller : MonoBehaviour
{
    public GameObject gObject;
    public AudioSource aSource;
    bool isVolumeOut;
    void Start()
    {
        
    }


    void Update()
    {
        if (isVolumeOut)
        {
            aSource.volume -= Time.deltaTime/4f;
        }
    }

    public void SetButton()
    {
        isVolumeOut = true;
        gObject.SetActive(true);
        StartCoroutine(LoadSceneButton());
    }

    public IEnumerator LoadSceneButton()
    {
        
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Enes");
    }
}
