using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour  //aqui simplemente contralamos el inicio del juego, el play para empezar el primer nivel y el exit para salir del programa.
{
   public void Play ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Exit()
    {
        Debug.Log("Exit...");
        Application.Quit();

    }
    

}
