using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jarro_bueno : MonoBehaviour
{
   
    public Collider2D jarracoll;
    public int damage = 1;


    // Start is called before the first frame update
    void Start()
    {

        jarracoll = GetComponent<Collider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        CharacterControler player = collision.gameObject.GetComponent<CharacterControler>();

        if (player != null)
        {
            Hit_score.hitsNumber += 1;
            GameObject.Destroy(this.gameObject);
        }
        if(collision.gameObject.tag == "floor")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}