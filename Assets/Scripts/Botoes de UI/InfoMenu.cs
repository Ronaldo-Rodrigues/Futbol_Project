using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoMenu : MonoBehaviour
{
    public Animator info;
    
    private AudioSource _musica;

    public Sprite somLigado, somDesligado;

    private Button btnSom;


    private void Start()
    {
        info = GameObject.FindGameObjectWithTag("InfoMenu").GetComponent<Animator>() as Animator;
        _musica = GameObject.Find("AudioManager").GetComponent<AudioSource>() as AudioSource;
        btnSom = GameObject.Find("SOM").GetComponent<Button>() as Button;
    }
    public void AnimaInfo()
    {
        info.Play("AnimaInfo");
    }

    public void FechaAnimaInfo()
    {
        info.Play("AnimaInfoInverse");
    }

    public void LigaDesligaSom()
    {
        _musica.mute = !_musica.mute;
        if(_musica.mute == true)
        {
            btnSom.image.sprite = somDesligado;
        }
        else
        {
            btnSom.image.sprite = somLigado;
        }
    }

    public void WebSite()
    {
        Application.OpenURL("www.facebook.com");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
