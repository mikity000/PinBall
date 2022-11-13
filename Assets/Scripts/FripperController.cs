using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FripperController : MonoBehaviour
{
    //HingeJointコンポーネントを入れる
    private HingeJoint myHingeJoint;

    //初期の傾き
    private float defaultAngle = 20;
    //弾いた時の傾き
    private float flickAngle = -20;

    void Start()
    {
        //HingeJointコンポーネント取得
        myHingeJoint = GetComponent<HingeJoint>();

        //フリッパーの傾きを設定
        SetAngle(defaultAngle);
    }

    void Update()
    {
        //UnityRemoteは「Application.platform」で判別できないため「touchCount」を使うことにした
        if (Input.touchCount == 0)
        {
            //左矢印キーを押した時左フリッパーを動かす
            if (Input.GetKeyDown(KeyCode.LeftArrow) && CompareTag("LeftFripper"))
                SetAngle(flickAngle);

            //右矢印キーを押した時右フリッパーを動かす
            if (Input.GetKeyDown(KeyCode.RightArrow) && CompareTag("RightFripper"))
                SetAngle(flickAngle);

            //矢印キー離された時フリッパーを元に戻す
            if (Input.GetKeyUp(KeyCode.LeftArrow) && CompareTag("LeftFripper"))
                SetAngle(defaultAngle);

            if (Input.GetKeyUp(KeyCode.RightArrow) && CompareTag("RightFripper"))
                SetAngle(defaultAngle);
        }
        else
        {
            //タッチ数
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

    //フリッパーの傾きを設定
    public void SetAngle(float angle)
    {
        JointSpring jointSpr = myHingeJoint.spring;
        jointSpr.targetPosition = angle;
        myHingeJoint.spring = jointSpr;
    }
}
