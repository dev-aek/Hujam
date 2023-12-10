using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }
}
