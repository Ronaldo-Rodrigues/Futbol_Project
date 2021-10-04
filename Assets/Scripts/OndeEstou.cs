using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OndeEstou : MonoBehaviour
{
    public int fase = -1;
    [SerializeField]
    private GameObject gameManagerGO, uiManagerGO;

    public static OndeEstou instance;

    public int bolaEmUso;

    private float _orthoSize = 5;

    [SerializeField]
    private float aspect = 1.66f;


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
        SceneManager.sceneLoaded += VerificaFase;

        bolaEmUso = PlayerPrefs.GetInt("BolaUse");
    }

    void VerificaFase(Scene cena, LoadSceneMode modo)
    {
        fase = SceneManager.GetActiveScene().buildIndex;

        if(fase != 4 && fase != 5 && fase != 6)
        {
            Instantiate(uiManagerGO);
            Instantiate(gameManagerGO);
            Camera.main.projectionMatrix = Matrix4x4.Ortho(-_orthoSize * aspect, _orthoSize * aspect, -_orthoSize, _orthoSize, Camera.main.nearClipPlane, Camera.main.farClipPlane);
        }
    }
}