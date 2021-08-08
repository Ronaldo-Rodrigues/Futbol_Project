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
    private Button loseJogaNovamenteBtn, loseMenuBtn; //lose Buttons
    [SerializeField]
    private Button winJogaNovamenteBtn, winMenuBtn, winAvancaBtn; //Win Bunttons
    
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
        PegaDados();
    }
    public void StartUI()
    {
        LigaDesligLoseUI();
    }
    void LigaDesligLoseUI()
    {
        //Desliga as UIs assim que o jogo inicia
        StartCoroutine(TempoDesligaUI());
    }

    void Carrega (Scene cena, LoadSceneMode modo)
    {
        PegaDados();
    }

    public void UpdateUI()
    {
        pontosUI.text = ScoreManager.instance.moedas.ToString();
        bolasUI.text = GameManager.instance.bolasNum.ToString();
        
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
      

    //Função de Jogar novamente a mesma cena ao perder
    void JogarNovamente()
    {
        if (!GameManager.instance.win)
        {
            SceneManager.LoadScene(OndeEstou.instance.fase);
        }
        else
        {
            SceneManager.LoadScene(OndeEstou.instance.fase);
        }
    }
    //Função de ir para o menu de Levels
    void   Levels()
    {
        if(GameManager.instance.win == false)
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            SceneManager.LoadScene(4);
        }
    }

    //Função de Avançar para o proximo Level
    void ProximaFase()
    {
        if(GameManager.instance.win == true)
        {
            int temp = OndeEstou.instance.fase + 1;
            SceneManager.LoadScene(temp);
        }
    }

    void PegaDados()
    {
        if (OndeEstou.instance.fase != 4)
        {
            //UI de pontos e bolas
            pontosUI = GameObject.Find("pontosUI").GetComponent<Text>();
            bolasUI = GameObject.Find("BolasUI").GetComponent<Text>();
      
                


            //paineis de UI
            losePanel = GameObject.Find("Lose_painel");
            winPanel = GameObject.Find("Win_painel");
            pausePanel = GameObject.Find("Pause_Panel");

            //pause UI
            pauseBtn = GameObject.Find("PauseBtn").GetComponent<Button>();
            pauseBtn_Return = GameObject.Find("PauseReturn").GetComponent<Button>();
            //Eventos de pause
            pauseBtn.onClick.AddListener(PauseGame);
            pauseBtn_Return.onClick.AddListener(PauseGameReturn);

            //Evento de lose
            //Evento Joga Novamente LoseUI
            loseJogaNovamenteBtn = GameObject.Find("LoseJogaNovamenteBtn").GetComponent<Button>();
            loseJogaNovamenteBtn.onClick.AddListener(JogarNovamente);
            //Evnto Menu fases Lose UI
            loseMenuBtn = GameObject.Find("LoseMenuBtn").GetComponent<Button>();
            loseMenuBtn.onClick.AddListener(Levels);

            //Evento de win
            //Evento Joga Novamete WinUI
            winJogaNovamenteBtn = GameObject.Find("WinJogarNovamenteBtn").GetComponent<Button>();
            winJogaNovamenteBtn.onClick.AddListener(JogarNovamente);
            //Evnto Menu fases Win UI
            winMenuBtn = GameObject.Find("WinMenuBtn").GetComponent<Button>();
            winMenuBtn.onClick.AddListener(Levels);
            //Evento de Avançar proximo Win Ui
            winAvancaBtn = GameObject.Find("proximoBtn").GetComponent<Button>();
            winAvancaBtn.onClick.AddListener(ProximaFase);

        }
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
