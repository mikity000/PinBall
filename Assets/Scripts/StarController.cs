using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    // ��]���x
    private float rotSpeed = 2.5f;

    void Start()
    {
        //��]���J�n����p�x��ݒ�
        transform.Rotate(0, Random.Range(0, 360), 0);
    }

    void Update()
    {
        //��]
        transform.Rotate(0, rotSpeed, 0);
    }
}
