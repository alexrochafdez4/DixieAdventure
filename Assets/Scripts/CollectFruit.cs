using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CollectFruit : MonoBehaviour // Este script permite que el jugador recolecte frutas en el juego al entrar en contacto con ellas.
                                          // Al recolectar una fruta, desaparece, luego activamos una animacion de recogida y se destruye.
                                          // ademas le pongo un sonido al cogerla
{    public AudioSource clip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);          
            Destroy(gameObject, 0.5f);
            clip.Play();
        }


    }
}