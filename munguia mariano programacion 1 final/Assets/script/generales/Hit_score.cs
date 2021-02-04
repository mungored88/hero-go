using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hit_score : MonoBehaviour
{

    public static int hitsNumber;
    private Text HitsScore;
    public int hitWin;
    public GameObject box;

    // Start is called before the first frame update
    void Start()
    {
        HitsScore = GetComponent<Text>();
        hitsNumber = 0;



    }
    // Update is called once per frame
    void Update()
    {
        HitsScore.text = "Score " + hitsNumber;

        if (hitsNumber == hitWin)
        {
            GameObject.Destroy(this.box);
        }
    }
}
