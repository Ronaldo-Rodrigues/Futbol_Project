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
        Debug.Log("clicou");
         for(int i = 0; i < LojadeBolas.instance.bolasList.Count; i++)
        {
            if (LojadeBolas.instance.bolasList[i].bolasID == bolasIDe && !LojadeBolas.instance.bolasList[i].comprou)
            {
                LojadeBolas.instance.bolasList[i].comprou = true;
            }
        }

        LojadeBolas.instance.UpdateSprite(bolasIDe);
        
    }
}
