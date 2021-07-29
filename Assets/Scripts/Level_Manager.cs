using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{

    [System.Serializable]
     public class Level
    {
        public string levelText;
        public bool autorizado;
        public int desbloquiado;
    }

   
    public GameObject botao;
    public Transform localBtn;
    public List<Level> levelList;

    void ListaAdd()
    {
        foreach (Level level in levelList)
        {
            GameObject btnNovo = Instantiate(botao) as GameObject;
            Botao_Level btnNew = btnNovo.GetComponent<Botao_Level>();
            btnNew.txtBtn.text = level.levelText;
            btnNew.desbloqueadoBtn = level.desbloquiado;
            btnNew.GetComponent<Button>().interactable = level.autorizado;

            if (PlayerPrefs.GetInt("Level" + btnNew.txtBtn.text) == 1)
            {
                level.desbloquiado = 1;
                level.autorizado = true;
            }
            btnNew.desbloqueadoBtn = level.desbloquiado;
            btnNew.GetComponent<Button>().interactable = level.autorizado;

            btnNovo.transform.SetParent(localBtn, false);
        }
    }


    void Start()
    {
        ListaAdd();
    }

   
    void Update()
    {
        
    }
}
