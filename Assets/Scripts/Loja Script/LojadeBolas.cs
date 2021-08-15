using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LojadeBolas : MonoBehaviour
{
    public static LojadeBolas instance;

    public List<BolasLoja> bolasList = new List<BolasLoja>();

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

     
            item.bolaPreco.text = b.bolaPreço.ToString();

            if(b.comprou == true)
            {
                item.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + b.nomeSprite);
            }
            else
            {
                item.bolaSprite.sprite = Resources.Load<Sprite>("Sprites/" + b.nomeSprite + "_cinza"); 
            }

        }
    }
}
