using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MataBolaMorteFX : MonoBehaviour
{
    
    void Start()
    {
       StartCoroutine( MataFX());
    }
IEnumerator MataFX()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }
}
