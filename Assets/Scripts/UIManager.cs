using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text pontosUI, bolasUI;
    public GameObject losePanel;
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
        LigaDesligLoseUI();
    }
    
    void Carrega (Scene cena, LoadSceneMode modo)
    {
        pontosUI = GameObject.Find("pontosUI").GetComponent<Text> ();
        bolasUI = GameObject.Find("BolasUI").GetComponent<Text>();
        losePanel = GameObject.Find("Lose_painel");
    }
    public void UpdateUI()
    {
        pontosUI.text = ScoreManager.instance.moedas.ToString();
        bolasUI.text = GameManager.instance.bolasNum.ToString();
    }

   public void GameOverUI()
    {
        losePanel.gameObject.SetActive(true);
    }
    IEnumerator TempoDesligaUI()
    {
        yield return new WaitForSeconds(0.001f);
        losePanel.gameObject.SetActive(false);
    }
    void LigaDesligLoseUI()
    {
        StartCoroutine(TempoDesligaUI());
    }
}
