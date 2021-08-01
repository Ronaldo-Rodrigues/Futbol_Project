using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public Text pontosUI, bolasUI;
    public GameObject losePanel,winPanel,pausePanel;
    [SerializeField]
    private Button pauseBtn;
    
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
        winPanel = GameObject.Find("Win_painel");
        pausePanel = GameObject.Find("Pause_Panel");
        pauseBtn = GameObject.Find("PauseBtn").GetComponent<Button>();
        pauseBtn.onClick.AddListener(PauseGame);
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
    public void WinGameUI()
    {
        winPanel.gameObject.SetActive(true);
    }
    void PauseGame()
    {
        pausePanel.SetActive(true);
        pausePanel.GetComponent<Animator>().Play("PauseUi_Move");
        Time.timeScale = 0;
    }
    IEnumerator TempoDesligaUI()
    {
        yield return new WaitForSeconds(0.001f);
        losePanel.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
    }
    void LigaDesligLoseUI()
    {
        StartCoroutine(TempoDesligaUI());
    }
}
