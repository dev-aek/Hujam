using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniPuzzleControler : MonoBehaviour
{
    public int sayac = 0;
    public GameObject mpCont;
    bool isOver;
    public FinalScripts finalScripts;
    public GameObject parent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (sayac == 3 && !isOver)
        {
            mpCont.SetActive(true);
            isOver = true;
            StartCoroutine("Example");
        }
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(2f);
        parent.SetActive(false);
        finalScripts.SetGameFinal();
    }
}
