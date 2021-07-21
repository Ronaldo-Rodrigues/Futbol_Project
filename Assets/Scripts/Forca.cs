using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Forca : MonoBehaviour
{
    private Rigidbody2D bola;
    private float force = 0;
    private Rotação rot;
    public Image seta2;
    // Start is called before the first frame update
    void Start()
    {
        bola = GetComponent<Rigidbody2D>();
        rot = GetComponent<Rotação>();
    }

    // Update is called once per frame
    void Update()
    {
        AplicaForca();
        ControlaForca(); 
    }
    void AplicaForca()
    {
        float x = force * Mathf.Cos(rot.zRotation * Mathf.Deg2Rad);
        float y = force * Mathf.Sin(rot.zRotation * Mathf.Deg2Rad);

        if (rot.liberaTiro == true)
        {
            bola.AddForce(new Vector2(x, y));
            rot.liberaTiro = false;
        }
    }

    void ControlaForca()
    {
        if(rot.liberaRot == true)
        {
            float moveX = Input.GetAxis("Mouse X");

            if(moveX < 0)
            {
                seta2.fillAmount += 1.5f * Time.deltaTime;
                force = seta2.fillAmount * 1000;
            }
            if (moveX > 0)
            {
                seta2.fillAmount -= 1.5f * Time.deltaTime;
                force = seta2.fillAmount * 1000;
            }
        }
    }
}
