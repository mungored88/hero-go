using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosQuestActivator : MonoBehaviour
{
    public ContadorClases Count;
    public GameObject portal;
    public GameObject Portal1;
    public GameObject Portal2;
    public GameObject Portal3;

    // Start is called before the first frame update
    void Start()
    {
        Portal1.SetActive(Count.GetLevel("level1")==false);
        Portal2.SetActive(Count.GetLevel("level2") == false);
        Portal3.SetActive(Count.GetLevel("level3") == false);
        bool Active= Count.BossQuest();
        portal.SetActive(Active);
    }

    
}
