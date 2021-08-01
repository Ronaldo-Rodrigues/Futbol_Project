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
    private Transform pos;
    
    public int bolasNum =  5, bolasEmCena = 0, tiro = 0;
       
    
    public bool bolaMorreu = false, win;
   
   

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
    void Carrega(Scene cena, LoadSceneMode modo)
    {
        pos = GameObject.Find("InicialPos").GetComponent<Transform>();
    }
    void Start()
    {
        ScoreManager.instance.GameStartScoreM();
        bolasNum = 5;
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
        if(bolasNum <= 0)
        {
            GameOver();
        }
        if(bolasNum > 0 && bolasEmCena == 0)
        {
            Instantiate(bola, new Vector2(pos.position.x, pos.position.y), Quaternion.identity);
            bolasEmCena += 1;
            bolasNum -= 1;
            tiro = 0;
        }
    }

    void GameOver()
    {
        UIManager.instance.GameOverUI();
    }
}
