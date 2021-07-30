using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoedasControl : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bola"))
        {
            ScoreManager.instance.ColetaMoedas(10);
            AudioManager.instance.SonsFXToca(1); 
            Destroy(this.gameObject);
        }
    }
}
