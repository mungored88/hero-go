using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boton : MonoBehaviour
{
    public void ClickInBoton (string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
    public void Exit()
    {
        Application.Quit();
    }
    public void ReserPlayerPref()
    {
       PlayerPrefs.DeleteAll();
    }
    public void OnEnable()
    {
        Cursor.visible = true;
    }
    public void MouseOff()
    {
        Cursor.visible = false;
    }
}
