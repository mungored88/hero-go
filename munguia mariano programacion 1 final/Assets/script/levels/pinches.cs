using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinches : MonoBehaviour
{
    public int damage;
    

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("me pincho");
        if ( other.gameObject.layer == 9)
        {
            
            other.gameObject.GetComponent<CharacterControler>().Life-=damage;
        }
    }
}
