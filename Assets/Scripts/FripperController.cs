using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJoint�R���|�[�l���g������
    private HingeJoint myHingeJoint;

    //�����̌X��
    private float defaultAngle = 20;
    //�e�������̌X��
    private float flickAngle = -20;

    void Start()
    {
        //HingeJoint�R���|�[�l���g�擾
        myHingeJoint = GetComponent<HingeJoint>();

        //�t���b�p�[�̌X����ݒ�
        SetAngle(defaultAngle);
    }

    void Update()
    {
        //UnityRemote�́uApplication.platform�v�Ŕ��ʂł��Ȃ����߁utouchCount�v���g�����Ƃɂ���
        if (Input.touchCount == 0)
        {
            //�����L�[�������������t���b�p�[�𓮂���
            if (Input.GetKeyDown(KeyCode.LeftArrow) && CompareTag("LeftFripper"))
                SetAngle(flickAngle);

            //�E���L�[�����������E�t���b�p�[�𓮂���
            if (Input.GetKeyDown(KeyCode.RightArrow) && CompareTag("RightFripper"))
                SetAngle(flickAngle);

            //���L�[�����ꂽ���t���b�p�[�����ɖ߂�
            if (Input.GetKeyUp(KeyCode.LeftArrow) && CompareTag("LeftFripper"))
                SetAngle(defaultAngle);

            if (Input.GetKeyUp(KeyCode.RightArrow) && CompareTag("RightFripper"))
                SetAngle(defaultAngle);
        }
        else
        {
            //�^�b�`��
            Touch[] touches = Input.touches;

            for (int i = 0; i < touches.Length; i++)
            {
                if ((touches[i].phase == TouchPhase.Began || touches[i].phase == TouchPhase.Stationary) && touches[i].position.x < Screen.width * 0.5f && CompareTag("LeftFripper"))
                    SetAngle(flickAngle);

                if (touches[i].phase == TouchPhase.Ended && touches[i].position.x < Screen.width * 0.5f && CompareTag("LeftFripper"))
                    SetAngle(defaultAngle);

                if ((touches[i].phase == TouchPhase.Began || touches[i].phase == TouchPhase.Stationary) && touches[i].position.x > Screen.width * 0.5f && CompareTag("RightFripper"))
                    SetAngle(flickAngle);

                if (touches[i].phase == TouchPhase.Ended && touches[i].position.x > Screen.width * 0.5f && CompareTag("RightFripper"))
                    SetAngle(defaultAngle);
            }

        }
    }

    //�t���b�p�[�̌X����ݒ�
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        myHingeJoint.spring = jointSpr;
    }
}
