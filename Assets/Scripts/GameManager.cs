using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField]
    private GameObject bola;
    public Transform pos;
    
    public int bolasNum, bolasEmCena = 0, tiro = 0;
    //public int ondeEstou;

    public bool JogoComecou;
    public bool win;
   
   

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
        pos = GameObject.Find("InicialPos").GetComponent<Transform>();
      
       
    }
    void Carrega(Scene cena, LoadSceneMode modo)
    {
        if(OndeEstou.instance.fase != 4)
        {
            pos = GameObject.Find("InicialPos").GetComponent<Transform>();
            GameStart();
            //ondeEstou = SceneManager.GetActiveScene().buildIndex;
        }

    }
    void Start()
    {
        GameStart();
        ScoreManager.instance.GameStartScoreM();
        
    }

    void Update()
    {
        ScoreManager.instance.UpdateScore();
        UIManager.instance.UpdateUI();
        NasceBolas();
        if(win == true)
        {
            UIManager.instance.WinGameUI();
        }
    }

    void NasceBolas()
    {
       
        if (bolasNum <= 0)
        {
            tiro = 1;
            GameOver();
        }
        if(bolasNum > 0 && bolasEmCena <= 0)
        {
            Instantiate(bola, new Vector2(pos.position.x, pos.position.y), Quaternion.identity);
            bolasEmCena += 1;
            bolasNum -= 1;
            tiro = 0;
            
        }
    }
    void GameStart()
    {
      
        JogoComecou = true;
        bolasNum = 5;
        bolasEmCena = 0;
        win = false;
        UIManager.instance.StartUI();
    }
    void GameOver()
    {
        UIManager.instance.GameOverUI();
        JogoComecou = false;
    }
    void WinGame()
    {
        UIManager.instance.WinGameUI();
        JogoComecou = false;
    }
}
