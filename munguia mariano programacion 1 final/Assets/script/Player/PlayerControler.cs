using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Transform player;
    public CharacterControler owner;

    // Start is called before the first frame update
    void Start()
    {
        owner = this.GetComponent<CharacterControler>();
    }

    // Update is called once per frame
    void Update()
    {
        owner.Move(Input.GetAxis("Horizontal"));

        if(Input.GetKeyDown(KeyCode.Space))
        {

            owner.Jump();
        }

       
       
    }
   
}
