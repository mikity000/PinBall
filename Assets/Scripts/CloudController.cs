using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    //�ŏ��T�C�Y
    private float minimum = 1.0f;
    //�g��k���X�s�[�h
    private float magSpeed = 10.0f;
    //�g�嗦
    private float magnification = 0.07f;

    void Update()
    {
        //�_���g��k��
        transform.localScale = new Vector3(minimum + Mathf.Sin(Time.time * magSpeed) * magnification, transform.localScale.y, minimum + Mathf.Sin(Time.time * magSpeed) * magnification);

    }
}
