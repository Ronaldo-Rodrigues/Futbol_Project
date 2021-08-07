using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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
            //para entrar na scena quando clicar no botao de fases
            btnNew.GetComponent<Button>().onClick.AddListener(() => ClickLevel("Fase_" + btnNew.txtBtn.text));

            btnNovo.transform.SetParent(localBtn, false);
        }
    }
    void ClickLevel(string level)
    {
        SceneManager.LoadScene(level);  
    }

    void Start()
    {
        ListaAdd();
    }

   
    void Update()
    {
        
    }
}
