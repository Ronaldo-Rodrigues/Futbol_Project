using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class LojadeBolas : MonoBehaviour
{
    public static LojadeBolas instance;

    public List<BolasLoja> bolasList = new List<BolasLoja>();
    public List<GameObject> bolaVitrineList = new List<GameObject>();
    public List<GameObject> compraBtnList = new List<GameObject>();

    public GameObject baseBolaItem;

    public Transform conteudo;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        FillList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FillList()
    {
        foreach(BolasLoja b in bolasList)
        {
            GameObject itensBola = Instantiate(baseBolaItem) as GameObject;
            itensBola.transform.SetParent(conteudo, false);
            BolasVitrine item = itensBola.GetComponent<BolasVitrine>();

            item.bolaID = b.bolasID;
            item.bolaPreco.text = b.bolaPreço.ToString();
            item.btnCompra.GetComponent<CompraBola>().bolasIDe = b.bolasID;

            //LISTA COMPRA BTN
            compraBtnList.Add(item.btnCompra);

            //LISTA BOLAS VITRINE
            bolaVitrineList.Add(itensBola);

            if(b.comprou == true)
            {
                item.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + b.nomeSprite);
                item.bolaPreco.text = "Comprado!";
            }
            else
            {
                item.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + b.nomeSprite + "_cinza"); 
            }

        }
    }

    //FUNÇÃO PARA FAZER A IMAGEM DA BOLA COMPRADA DE CINZA PARA COLORIDO
   public void UpdateSprite(int bola_ID)
    {
        for (int i = 0; i < bolaVitrineList.Count; i++)
        {
            BolasVitrine bolasVitrineScript = bolaVitrineList[i].GetComponent<BolasVitrine>();

            if(bolasVitrineScript.bolaID == bola_ID)
            {
                for (int j = 0; j < bolasList.Count; j++)
                {
                    if (bolasList[j].bolasID == bola_ID)
                    {
                        if (bolasList[j].comprou == true)
                        {
                            bolasVitrineScript.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + bolasList[j].nomeSprite);
                            bolasVitrineScript.bolaPreco.text = "Comprado!";
                        }
                        else
                        {
                            bolasVitrineScript.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + bolasList[j].nomeSprite + "_cinza");
                        }
                    }
                }
            }
        }
    }
}
