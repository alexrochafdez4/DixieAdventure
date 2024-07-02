using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class UIManager : MonoBehaviour //Este script gestiona la interfaz de usuario UI , las funcionalidades para opciones del menú y los sonidos de botones.
{
    public GameObject panelOptions;
    public AudioSource clip;

    public void PanelOptions()
    {
        Debug.Log("PanelOptions clicked");
        Time.timeScale = 0;
        panelOptions.SetActive(true);
    }

    public void Return()
    {
        Debug.Log("Return clicked");
        Time.timeScale = 1;
        panelOptions.SetActive(false);
    }

    public void GoMainMenu()
    {
        Debug.Log("GoMainMenu clicked");
        Time.timeScale = 1;
        SceneManager.LoadScene("TitleScene");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame clicked");
        Application.Quit();
    }

    public void PlaySoundButton()
    {
        clip.Play();
    }
}
