using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRespawn : MonoBehaviour //en este script manejamos la vida del jugador, el respawn después de morir, los puntos de control y los efectos que tienes si pierdes vida.
{
    public GameObject[] hearts;
    private int life;

    private float checkPointPositionX, checkPointPositionY;
    private string currentScene;

    public Animator animator;
    public AudioSource hitSound;
    public GameObject gameOverImage; 
    public AudioSource gameOverMusic; 

    private bool isInvulnerable = false;  

    void Start() 
    {
        currentScene = SceneManager.GetActiveScene().name; //aqui reiniciamos las vidas y actualizamos el punto de control.

        if (PlayerPrefs.HasKey("life"))
        {
            life = PlayerPrefs.GetInt("life");
        }
        else
        {
            life = hearts.Length;
        }

        if (PlayerPrefs.GetString("currentScene") == currentScene && PlayerPrefs.GetFloat("checkPointPositionX") != 0)
        {
            transform.position = new Vector2(PlayerPrefs.GetFloat("checkPointPositionX"), PlayerPrefs.GetFloat("checkPointPositionY"));
        }
        else
        {
            PlayerPrefs.SetFloat("checkPointPositionX", 0);
            PlayerPrefs.SetFloat("checkPointPositionY", 0);
            PlayerPrefs.SetString("currentScene", currentScene);
        }

        UpdateHearts();
    }

    private void CheckLife() //si las vidas llegan a 0 , el jugador cambia a una animacion de muerte y le pongo una musica de muerte.
    {
        if (life < 1)
        {
            Destroy(hearts[0].gameObject);
            animator.Play("Dead");

            
            gameOverImage.SetActive(true);

           
            if (gameOverMusic != null)
            {
                gameOverMusic.Play();
            }

           
            StartCoroutine(GameOverSequence());
        }
        else if (life < 2)
        {
            Destroy(hearts[1].gameObject);
            animator.Play("HitAnimation");
        }
        else if (life < 3)
        {
            Destroy(hearts[2].gameObject);
            animator.Play("HitAnimation");
        }

        PlayerPrefs.SetInt("life", life);
    }

    private IEnumerator GameOverSequence() //cuando pierdes todas las vidas te regreso al menu principal.
    {
       
        yield return new WaitForSeconds(2f);

        
        PlayerPrefs.SetFloat("checkPointPositionX", 0);
        PlayerPrefs.SetFloat("checkPointPositionY", 0);
        PlayerPrefs.SetString("currentScene", "");
        PlayerPrefs.DeleteKey("life");
        SceneManager.LoadScene(0);
    }


    public void ReachedCheckPoint(float x, float y) //chekcpoint
    {
        PlayerPrefs.SetFloat("checkPointPositionX", x);
        PlayerPrefs.SetFloat("checkPointPositionY", y);
        PlayerPrefs.SetString("currentScene", currentScene);
    }

    public void PlayerHitted() //cuando el jugador es golpeado le resto una vida y ademas le agrego un sonido y animacion.
    {
        if (!isInvulnerable)
        {
            life--;
            CheckLife();
            PlayHitSound();
            StartCoroutine(BecomeTemporarilyInvulnerable());
        }
    }

    private void PlayHitSound()
    {
        if (hitSound != null)
        {
            hitSound.Play();
        }
        else
        {
            Debug.LogWarning("Error");
        }
    }

    private IEnumerator BecomeTemporarilyInvulnerable()
    {
        isInvulnerable = true;
        yield return new WaitForSeconds(2); 
        isInvulnerable = false;
    }

    private IEnumerator RestartGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        PlayerPrefs.SetFloat("checkPointPositionX", 0);
        PlayerPrefs.SetFloat("checkPointPositionY", 0);
        PlayerPrefs.SetString("currentScene", "");
        PlayerPrefs.DeleteKey("life");
        SceneManager.LoadScene(0);
    }

    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < life)
            {
                hearts[i].SetActive(true);
            }
            else
            {
                hearts[i].SetActive(false);
            }
        }
    }
}
