using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class MoveScript : MonoBehaviour
{
    public GameObject target;
    public float waitTime;

    void Start()
    {
        transform.DOMove(target.transform.position, waitTime);
    }

}
