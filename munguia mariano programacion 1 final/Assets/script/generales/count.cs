using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class count : MonoBehaviour
{
    public ContadorClases CountQuest;
    public string NameLevel;

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.tag == "Player")
        {
            CountQuest.SaveLevel(NameLevel);
            CountQuest.QuestDone();
        }
    }
}
