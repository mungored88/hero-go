using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform_Move : MonoBehaviour
{
    public GameObject Player;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" )
        {
            Player.transform.parent = transform;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.parent = transform;
        }
    }
}
