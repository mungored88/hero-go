using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefowardpin : MonoBehaviour
{
    public int Speed;
    private Transform pinMove;


    // Start is called before the first frame update
    void Start()
    {
        pinMove = GetComponent<Transform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        pinMove.position += pinMove.right * Speed * Time.deltaTime;


    }
}
