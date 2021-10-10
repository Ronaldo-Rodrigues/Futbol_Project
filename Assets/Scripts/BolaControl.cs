using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolaControl : MonoBehaviour
{   
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
    //paredes de matar o personagem
    public Transform paredeLD, paredeLE;
    //Morte bola FX obj
    [SerializeField]
    private GameObject morteBolaFX;

    private Collider2D toqueCol;

    private void Awake()
    {
        setaGo = GameObject.Find("Seta1"); //seta borda que sera preenchida
        seta2 = setaGo.transform.GetChild(0).gameObject; //para pegar a img de Fill da seta1 no child;
        setaGo.GetComponent<Image>().enabled = false; //para desligar as setas
        seta2.GetComponent<Image>().enabled = false;
        paredeLD = GameObject.Find("ParedeLD").GetComponent<Transform>();
        paredeLE = GameObject.Find("ParedeLE").GetComponent<Transform>();
    }
    void Start()
    {
    
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

        //morrer ao passar da parede
        Paredes();
    }

    void PosicionaSeta()
    {   
        //fixa a seta na bola
        setaGo.GetComponent<Image>().rectTransform.position = transform.position;
    }

    void RotacaoSeta()
    {
        //faz a rotação da seta
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
        //barra a rotação 180 da seta
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
        if (GameManager.instance.tiro == 0)
        {
            setaGo.GetComponent<Image>().enabled = true;
            seta2.GetComponent<Image>().enabled = true;
            liberaRot = true;

            toqueCol = GameObject.FindGameObjectWithTag("Toque").GetComponentInChildren<Collider2D>();
        }

    }
    private void OnMouseUp()
    {
        AudioManager.instance.SonsFXToca(0);
        setaGo.GetComponent<Image>().enabled = false;
        seta2.GetComponent<Image>().enabled = false;

        if (GameManager.instance.tiro == 0 && force > 0)
        {
            liberaRot = false;
            liberaTiro = true;
            AudioManager.instance.SonsFXToca(0);
            GameManager.instance.tiro = 1;
            seta2.GetComponent<Image>().fillAmount = 0;
            toqueCol.enabled = false;
            StartCoroutine(MorreAposTempo());
            
        }
       
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
        //faz com que o rb da bola passe de kinematic para dinamic, assim da termp de ver a  animação
        this.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void Paredes()
    {
        
        if(this.transform.position.x > paredeLD.position.x)
        {
            Destroy(this.gameObject);
            GameManager.instance.bolasEmCena -= 1;   
        }
        if (this.transform.position.x < paredeLE.position.x)
        {
            
            Destroy(this.gameObject);
            GameManager.instance.bolasEmCena -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Serra"))
        {
            Instantiate(morteBolaFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            GameManager.instance.bolasEmCena -= 1;
        }
        if (other.gameObject.CompareTag("Win"))
        {
            GameManager.instance.win = true;
            int temp = OndeEstou.instance.fase+1;
            temp++;
            PlayerPrefs.SetInt("Level" + temp, 1);
        }
    }

    //Função temporaria de destruir a bola apos um tempo de ser lançada
    IEnumerator MorreAposTempo()
    {
        yield return new WaitForSeconds(4);
        if (GameManager.instance.win == false)
        {
            Instantiate(morteBolaFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
           
            GameManager.instance.bolasEmCena -= 1;
        }
        else { yield return 1; }

    }
  
}
