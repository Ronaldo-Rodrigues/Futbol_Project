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
    private Button pauseBtn,pauseBtn_Return;
   [SerializeField]
    private Button jogaNovamenteBtn, MenuBtn;

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
        LigaDesligLoseUI();
        SceneManager.sceneLoaded += Carrega;
    }
    public void StartUI()
    {
        LigaDesligLoseUI();
    }
    
    void Carrega (Scene cena, LoadSceneMode modo)
    {   
        //paineis de UI
        pontosUI = GameObject.Find("pontosUI").GetComponent<Text> ();
        bolasUI = GameObject.Find("BolasUI").GetComponent<Text>();
        losePanel = GameObject.Find("Lose_painel");
        winPanel = GameObject.Find("Win_painel");
        pausePanel = GameObject.Find("Pause_Panel");
       
        //pause UI
        pauseBtn = GameObject.Find("PauseBtn").GetComponent<Button>();
        pauseBtn.onClick.AddListener(PauseGame);
        pauseBtn_Return = GameObject.Find("PauseReturn").GetComponent<Button>();
        pauseBtn_Return.onClick.AddListener(PauseGameReturn);
        
        //Joga Novamente UI
        jogaNovamenteBtn = GameObject.Find("LoseJogaNovamenteBtn").GetComponent<Button>();
        jogaNovamenteBtn.onClick.AddListener(JogarNovamente);
        
        //Menu fases UI
        MenuBtn = GameObject.Find("LoseMenuBtn").GetComponent<Button>();
        //MenuBtn = .onClick.AddListener();
    }
    public void UpdateUI()
    {
        pontosUI.text = ScoreManager.instance.moedas.ToString();
        bolasUI.text = GameManager.instance.bolasNum.ToString();
    }

    //função de popup de UI de GameOver
    public void GameOverUI()
    {
        losePanel.gameObject.SetActive(true);
    }
    //função de popup de UI de Win
    public void WinGameUI()
    {
        winPanel.gameObject.SetActive(true);
    }
    //Função de parar o tempo, o jogo e tbm de voltar a rodar
    void PauseGame()
    {
        pausePanel.SetActive(true); 
        pausePanel.GetComponent<Animator>().Play("PauseUi");
        Time.timeScale = 0;
    }
    void PauseGameReturn()
    {
        pausePanel.GetComponent<Animator>().Play("PauseUi_Return");
        Time.timeScale = 1;
        StartCoroutine(EsperaPause());
    }

    //Função de Jogar novamente a mesma cena ao perder
    void JogarNovamente()
    {
        SceneManager.LoadScene(GameManager.instance.ondeEstou);
    }

    //Desliga as UIs assim que o jogo inicia
    void LigaDesligLoseUI()
    {
        StartCoroutine(TempoDesligaUI());
    }

    IEnumerator EsperaPause()
    {
        yield return new WaitForSeconds(.8f);
    }
    IEnumerator TempoDesligaUI()
    {
        yield return new WaitForSeconds(0.001f);
        losePanel.gameObject.SetActive(false);
        winPanel.gameObject.SetActive(false);
        pausePanel.gameObject.SetActive(false);
    }
    
}
