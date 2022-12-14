using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    // ‰ñ“]‘¬“x
    private float rotSpeed = 2.5f;

    void Start()
    {
        //‰ñ“]‚ğŠJn‚·‚éŠp“x‚ğİ’è
        transform.Rotate(0, Random.Range(0, 360), 0);
    }

    void Update()
    {
        //‰ñ“]
        transform.Rotate(0, rotSpeed, 0);
    }
}
