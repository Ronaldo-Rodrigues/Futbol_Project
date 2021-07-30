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
    private int bolasNum =2;
    private bool bolaMorreu = false;
    private int bolasEmCena = 0;
    private Transform pos;

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
    }

    void Update()
    {
        ScoreManager.instance.UpdateScore();
        UIManager.instance.UpdateUI();
        NasceBolas();
    }

    void NasceBolas()
    {
        if(bolasNum > 0 && bolasEmCena == 0)
        {
            Instantiate(bola, new Vector2(pos.position.x, pos.position.y), Quaternion.identity);
            bolasEmCena += 1;
        }
    }
}
