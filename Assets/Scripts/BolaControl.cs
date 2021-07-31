using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolaControl : MonoBehaviour
{   
    //pos da seta
    [SerializeField]
    private Transform posStart;
    //seta
    public GameObject setaGo;
    //rotação
    public float zRotation;
    public bool liberaRot = false;
    public bool liberaTiro = false;
    //força
    private Rigidbody2D bola;
    private float force = 0;
    public GameObject seta2;

    private void Awake()
    {
        setaGo = GameObject.Find("Seta1");
        if(setaGo == null)
        {
            Debug.Log("naodeu");
        }
        seta2 = setaGo.transform.GetChild(0).gameObject;
        setaGo.SetActive(false);
    }
    void Start()
    {
        posStart = GameObject.Find("InicialPos").GetComponent<Transform>();
        PosicionaBola();

        //força
        bola = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PosicionaSeta();
        RotacaoSeta();
        InputdeRotacao();
        LimitaRotacao();
        
        //força
        AplicaForca();
        ControlaForca();
    }

    void PosicionaSeta()
    {
        setaGo.GetComponent<Image>().rectTransform.position = transform.position;

    }
    void PosicionaBola()
    {
        this.gameObject.transform.position = posStart.position;
    }
    void RotacaoSeta()
    {
        setaGo.GetComponent<Image>().rectTransform.eulerAngles = new Vector3(0, 0, zRotation);
    }
    void InputdeRotacao()
    {
        if (liberaRot == true)
        {
            float moveY = Input.GetAxis("Mouse Y");

            if (zRotation < 90)
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
       // setaGo.GetComponent<Image>();
        setaGo.SetActive(true);
        liberaRot = true;

    }
    private void OnMouseUp()
    {
        AudioManager.instance.SonsFXToca(0);
        //setaGo.GetComponent<Image>();
        setaGo.SetActive(false);
        liberaRot = false;
        liberaTiro = true;
    }

    //força
    void AplicaForca()
    {
        float x = force * Mathf.Cos(zRotation * Mathf.Deg2Rad);
        float y = force * Mathf.Sin(zRotation * Mathf.Deg2Rad);

        if (liberaTiro == true)
        {
            bola.AddForce(new Vector2(x, y));
            liberaTiro = false;
        }
    }

    void ControlaForca()
    {
        if (liberaRot == true)
        {
            float moveX = Input.GetAxis("Mouse X");

            if (moveX < 0)
            {
                seta2.GetComponent<Image>().fillAmount += 1.5f * Time.deltaTime;
                force = seta2.GetComponent<Image>().fillAmount * 1000;
            }
            if (moveX > 0)
            {
                seta2.GetComponent<Image>().fillAmount -= 1.5f * Time.deltaTime;
                force = seta2.GetComponent<Image>().fillAmount * 1000;
            }
        }
    }
    void BolaDinamica()
    {
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }
}
