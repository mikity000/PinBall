using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour
{
    // Material������
    Material myMaterial;

    // Emission�̍ŏ��l
    private float minEmission = 0.2f;
    // Emission�̋��x
    private float magEmission = 2.0f;
    // �p�x
    private int degree = 0;
    //�������x
    private int speed = 5;
    // �^�[�Q�b�g�̃f�t�H���g�̐F
    Color defaultColor = Color.white;

    void Start()
    {

        // �^�O�ɂ���Č��点��F��ς���
        if (CompareTag("SmallStar"))
        {
            defaultColor = Color.white;
        }
        else if (CompareTag("LargeStar"))
        {
            defaultColor = Color.yellow;
        }
        else if (CompareTag("SmallCloud") || CompareTag("LargeCloud"))
        {
            defaultColor = Color.cyan;
        }

        //�I�u�W�F�N�g�ɃA�^�b�`���Ă���Material���擾
        myMaterial = GetComponent<Renderer>().material;

        //�I�u�W�F�N�g�̍ŏ��̐F��ݒ�
        myMaterial.SetColor("_EmissionColor", defaultColor * minEmission);
    }

    void Update()
    {

        if (degree >= 0)
        {
            // ���点�鋭�x���v�Z����
            Color emissionColor = defaultColor * (minEmission + Mathf.Sin(degree * Mathf.Deg2Rad) * magEmission);

            // �G�~�b�V�����ɐF��ݒ肷��
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //���݂̊p�x������������
            degree -= speed;
        }
    }

    //�Փˎ��ɌĂ΂��֐�
    void OnCollisionEnter(Collision other)
    {
        //�p�x��180�ɐݒ�
        degree = 180;
    }
}
