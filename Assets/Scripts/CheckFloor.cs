using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class CheckFloor : MonoBehaviour //Este script detecta si el jugador está en contacto con el suelo. Esto me permite poder saltar solo cuando el jugador este en el suelo.

{
    public static bool isFloor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isFloor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("floor"))
        {
            isFloor = false;
        }
    }

}