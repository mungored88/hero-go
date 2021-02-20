using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stones : MonoBehaviour
{
    public ContadorClases Count;
    public GameObject stone1;
    public GameObject stone2;
    public GameObject stone3;

    // Start is called before the first frame update
    void Start()
    {

        stone1.SetActive(Count.GetLevel("level1") == true);
        stone2.SetActive(Count.GetLevel("level2") == true);
        stone3.SetActive(Count.GetLevel("level3") == true);
    }

    
}
