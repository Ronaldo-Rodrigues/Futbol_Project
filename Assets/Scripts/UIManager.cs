using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text pontosUI;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        SceneManager.sceneLoaded += Carrega;
    }
    
    void Carrega (Scene cena, LoadSceneMode modo)
    {
        pontosUI = GameObject.Find("pontosUI").GetComponent<Text> (); 
    }
    public void UpdateUI()
    {
        pontosUI.text = ScoreManager.instance.moedas.ToString();
    }
}
