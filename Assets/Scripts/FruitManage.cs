using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManage : MonoBehaviour
{
    public GameObject LevelUpLogo;
    public Text totalFruits;
    public Text fruitsCollected;
    private int totalFruitsInLevel;

    private void Start()
    {
        totalFruitsInLevel = transform.childCount;
    }

    private void Update()
    {
        AllFruitsAreCollected();
        totalFruits.text = totalFruitsInLevel.ToString();
        fruitsCollected.text = transform.childCount.ToString();
    }

    public void AllFruitsAreCollected()
    {
        if (transform.childCount == 0)
        {
            Debug.Log("Todas las frutas conseguidas!!! Enhorabuena!!!");
            LevelUpLogo.gameObject.SetActive(true);
            Invoke("ChangeScene", 2);
        }
    }

    void ChangeScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 10)  
        {
            SceneManager.LoadScene("LevelWin");  
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
}

