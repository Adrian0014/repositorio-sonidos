using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private SFXManager sfxManager;
    private BGMManager bgmManager;


    void Awake()
    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        bgmManager = GameObject.Find("BGMManager").GetComponent<BGMManager>();
    }


    public void DeathMario()
    {
        sfxManager.DeathSound();
        bgmManager.StopBGM();
    }

    public void Victoria()
    {
        sfxManager.MetaSound();
        bgmManager.StopBGM();
    }

    public void TengoMoneda(GameObject coins)
    {
        sfxManager.CoinSound();
        Destroy(coins, 0.1f);
    }


    //Funciona para matar Goombas
    public void DeathGoomba(GameObject goomba)
    {
        //Variable para el animator del goomba
        Animator goombaAnimator;
        //variable para el script del goomba
        Enemy goombaScript;
        //variable para el colider
        BoxCollider2D goombaCollider;

        //asignamos la variable
        goombaScript = goomba.GetComponent<Enemy>();
        goombaAnimator = goomba.GetComponent<Animator>();
        goombaCollider = goomba.GetComponent<BoxCollider2D>();
        //cambiamos a la animacion de muerte
        goombaAnimator.SetBool("GoombaDeath", true);

        //cambiamos la variable del goomba a false
        goombaScript.isAlive = false;

        //Ajustamos el collider
        /*goombaCollider. size = new Vector2(1, 0.47f);
        goombaCollider.offset =new Vector2(0, 0.26f);*/

        //Desactivo collider
        goombaCollider.enabled = false;

        //destruimos el goomba
        Destroy(goomba, 0.3f);

        //llamamos la funcion del sonido de muerte del goomba
        sfxManager.GoombaSound();
    }
}
   
