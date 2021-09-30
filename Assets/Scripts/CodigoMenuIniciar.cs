using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CodigoMenuIniciar : MonoBehaviour
{
    //animator da barra de confuguração
    private Animator _barraAnim;

    private bool _sobe;

    //botao de iniciar o jogo
    public void Jogar()
    {
        SceneManager.LoadScene(4);
    }

    //função de animação da barra de config
    public void AnimaMenu()
    {
        _barraAnim = GameObject.FindGameObjectWithTag("BarraAnimTag").GetComponent<Animator>();

        if (_sobe == false)
        {
            _barraAnim.Play("Move");
            _sobe = true;
        }
        else
        {
            _barraAnim.Play("Move_Inverse");
            _sobe = false;
        }

        
    }
}


