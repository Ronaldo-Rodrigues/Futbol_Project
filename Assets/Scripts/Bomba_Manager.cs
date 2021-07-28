﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject bombaFX;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Bola"))
        {
            Instantiate(bombaFX, new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity); 
        }
    }
}
