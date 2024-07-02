using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWinManager : MonoBehaviour //aqui gestionamos la victoria del jugador. Cuando el jugador gana, se muestra una imagen de victoria y reproduce música de victoria.
{                                           //luego devuelve al jugador al menú principal.
    public GameObject gameWinImage; 
    public AudioSource gameWinMusic; 
    public GameWinManager gameWinManager;



    private void Start()
    {
       
        gameWinImage.SetActive(false);
    }

    public void OnPlayerWins()
    {
        
        gameWinImage.SetActive(true);

        
        if (gameWinMusic != null)
        {
            gameWinMusic.Play();
        }

        
        StartCoroutine(ReturnToMainMenuAfterDelay(5f)); 
    }


    private IEnumerator ReturnToMainMenuAfterDelay(float delay)
    {
        
        yield return new WaitForSeconds(delay);

        
        SceneManager.LoadScene("MainMenu");
    }

    private void Update()
    {
        
        if (PlayerHasWon())
        {
            gameWinManager.OnPlayerWins();
        }
    }
    private bool PlayerHasWon()
    {
        
        return false;
    }


}
