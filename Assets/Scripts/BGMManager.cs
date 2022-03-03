using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    private AudioSource _audioSoucer;

    void Awake()
     {
        //Asignamos la variable
        _audioSoucer = GetComponent<AudioSource>();
     }
    // Start is called before the first frame update
    void Start()
    {
        _audioSoucer.Play();
    }

    //Funcion para parar el BMG
    public void StopBGM()
    {
        _audioSoucer.Stop();
    }
}
