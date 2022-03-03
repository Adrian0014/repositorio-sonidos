using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    //clip de audio para la muerte de mario
    public AudioClip deathSFX;
    //clip de audio muerte goomba
    public AudioClip goombaSFX;
    //clip de audio tocar bandera
    public AudioClip metaSFX;
    //clip de audio conseguir moneda
    public AudioClip coinSFX;
    //variable del audio source
    private AudioSource _audioSource;


    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }


    public void DeathSound()
    {
        _audioSource.PlayOneShot(deathSFX);
    }

    public void GoombaSound()
    {
        _audioSource.PlayOneShot(goombaSFX);
    }

    public void MetaSound()
    {
        _audioSource.PlayOneShot(metaSFX);
    }

    public void CoinSound()
    {
        _audioSource.PlayOneShot(coinSFX);
    }

   
}
