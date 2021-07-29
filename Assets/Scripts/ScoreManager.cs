using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int moedas;

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

    }
    public void GameStartScoreM()
    {
        if (PlayerPrefs.HasKey("MoedasSave"))
        {
            moedas = PlayerPrefs.GetInt("MoedasSave");
        }
        else
        {
            moedas = 100;
            PlayerPrefs.SetInt("MoedasSave", moedas);
        }
    }
    public void UpdateScore()
    {
        moedas = PlayerPrefs.GetInt("MoedasSave");
    }

    public void ColetaMoedas(int coin)
    {
        moedas += coin;
        SalvaMoedas(moedas);
    }

    public void PerdeMoedas(int coin)
    {
        moedas -= coin;
        SalvaMoedas(moedas);
    }

    public void SalvaMoedas(int coin)
    {
        PlayerPrefs.SetInt("MoedasSave", coin);
    }
}
