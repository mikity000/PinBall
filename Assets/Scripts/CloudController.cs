using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
    //ç≈è¨ÉTÉCÉY
    private float minimum = 1.0f;
    //ägëÂèkè¨ÉXÉsÅ[Éh
    private float magSpeed = 10.0f;
    //ägëÂó¶
    private float magnification = 0.07f;

    void Update()
    {
        //â_ÇägëÂèkè¨
        transform.localScale = new Vector3(minimum + Mathf.Sin(Time.time * magSpeed) * magnification, transform.localScale.y, minimum + Mathf.Sin(Time.time * magSpeed) * magnification);

    }
}
