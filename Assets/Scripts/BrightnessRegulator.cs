using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrightnessRegulator : MonoBehaviour
{
    // Materialを入れる
    Material myMaterial;

    // Emissionの最小値
    private float minEmission = 0.2f;
    // Emissionの強度
    private float magEmission = 2.0f;
    // 角度
    private int degree = 0;
    //発光速度
    private int speed = 5;
    // ターゲットのデフォルトの色
    Color defaultColor = Color.white;

    void Start()
    {

        // タグによって光らせる色を変える
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

        //オブジェクトにアタッチしているMaterialを取得
        myMaterial = GetComponent<Renderer>().material;

        //オブジェクトの最初の色を設定
        myMaterial.SetColor("_EmissionColor", defaultColor * minEmission);
    }

    void Update()
    {

        if (degree >= 0)
        {
            // 光らせる強度を計算する
            Color emissionColor = defaultColor * (minEmission + Mathf.Sin(degree * Mathf.Deg2Rad) * magEmission);

            // エミッションに色を設定する
            myMaterial.SetColor("_EmissionColor", emissionColor);

            //現在の角度を小さくする
            degree -= speed;
        }
    }

    //衝突時に呼ばれる関数
    void OnCollisionEnter(Collision other)
    {
        //角度を180に設定
        degree = 180;
    }
}
