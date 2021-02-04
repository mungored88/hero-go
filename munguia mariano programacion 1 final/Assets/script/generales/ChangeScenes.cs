using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ChangeScenes : MonoBehaviour
{
    public string SceneM;

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("transportando al nivel");

        if (other.gameObject.tag == "Player")
        {
          Invoke("Change",0.1f);
        }
    }

    public void Change()
    {
        SceneManager.LoadScene(SceneM);
    }
    
}
