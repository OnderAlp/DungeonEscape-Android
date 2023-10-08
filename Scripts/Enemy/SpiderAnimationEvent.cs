using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    private Spider _spider;

    private void Start()
    {
        _spider = transform.parent.GetComponent<Spider>();
    }
    public void Fire()
    {
        _spider.Attack();
    }
}
