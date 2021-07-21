﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotação : MonoBehaviour
{
    [SerializeField]
    private Transform posStart;
    [SerializeField]
    private Image setaImage;

    public float zRotation;
    public bool liberaRot = false;
    public bool liberaTiro = false;

    void Start()
    {
        PosicionaSeta();
        PosicionaBola();
    }

    // Update is called once per frame
    void Update()
    {
        RotacaoSeta();
        InputdeRotacao();
        LimitaRotacao();
    }

    void PosicionaSeta()
    {
        setaImage.rectTransform.position = posStart.position;

    }
    void PosicionaBola()
    {
        this.gameObject.transform.position = posStart.position;
    }
    void RotacaoSeta()
    {
        setaImage.rectTransform.eulerAngles = new Vector3(0, 0, zRotation);
    }
    void InputdeRotacao()
    {
        if (liberaRot == true)
        {
            float moveY = Input.GetAxis("Mouse Y");

            if(zRotation < 90)
            {
                if (moveY < 0)
                {
                    zRotation += 5f;
                }
            }
            if (zRotation > 0)
            {
                if (moveY > 0)
                {
                    zRotation -= 5f;
                }
            }          
        }  
    }

    void LimitaRotacao()
    {
        if (zRotation >= 90)
        {
            zRotation = 90;
        }
        if (zRotation <= 0)
        {
            zRotation = 0;
        }
    }
    private void OnMouseDown()
    {
        liberaRot = true;
    }
    private void OnMouseUp()
    {
        liberaRot = false;
        liberaTiro = true;
    }
}
 