using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CompraBola : MonoBehaviour
{
    public int bolasIDe;
    //para mudar o nome no botao ao comprar
    public Text btnText;

    

    public void CompraBolaBtn()
    {
       
         for(int i = 0; i < LojadeBolas.instance.bolasList.Count; i++)
        {
            if (LojadeBolas.instance.bolasList[i].bolasID == bolasIDe && !LojadeBolas.instance.bolasList[i].comprou)
            {
                LojadeBolas.instance.bolasList[i].comprou = true;
                UpdateCompraBtn();
            }
            else if (LojadeBolas.instance.bolasList[i].bolasID == bolasIDe && LojadeBolas.instance.bolasList[i].comprou)
            {
                UpdateCompraBtn();
            }
        }

        LojadeBolas.instance.UpdateSprite(bolasIDe);
        
    }

    void UpdateCompraBtn()
    {
        btnText.text = "Usando";
        for (int i = 0; i < LojadeBolas.instance.compraBtnList.Count; i++)
        {
            CompraBola compraBolaScript = LojadeBolas.instance.compraBtnList[i].GetComponent<CompraBola>();
            
            for(int j = 0; j < LojadeBolas.instance.bolasList.Count; j++)
            {
                if (LojadeBolas.instance.bolasList[j].bolasID == compraBolaScript.bolasIDe && LojadeBolas.instance.bolasList[j].comprou && LojadeBolas.instance.bolasList[j].bolasID != bolasIDe)
                {
                    compraBolaScript.btnText.text = "Usar";
                }
            }
        }
    }
}
