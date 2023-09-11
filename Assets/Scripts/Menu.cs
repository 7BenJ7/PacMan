using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public static Menu Instance;

    [Header("Canvas")]
    [SerializeField] 
    private Canvas menu;
    [SerializeField] 
    private Canvas credits;

    
    
  
    private void Awake()
    {
        if(Instance != null) Destroy(Instance.gameObject);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        credits.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
        
        AudioManager.Instance.PlayMusic("Menu", true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Martin2");
    }

    public void Quit()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    public void Credits()
    {
        menu.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
    }

    public void ReturnToMenu()
    {
        credits.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }
    
}