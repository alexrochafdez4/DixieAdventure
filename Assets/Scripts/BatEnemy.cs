using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatEnemy : MonoBehaviour //es parecido al de las rocas, permite que el bat cause da�o al jugador cuando colisiona con �l.
                                      //Al colisionar con el jugador, se llama a la funci�n PlayerHitted() del script PlayerRespawn, que maneja la l�gica de p�rdida de vidas, animaciones, etc.
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("Player Damaged");
            collision.transform.GetComponent<PlayerRespawn>().PlayerHitted();
        }

    }
}
