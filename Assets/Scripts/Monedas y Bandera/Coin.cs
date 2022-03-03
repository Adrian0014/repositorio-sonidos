using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
   void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals("DestroyCoin"))
        {
            Destroy(other.gameObject);
        }
    }
}
