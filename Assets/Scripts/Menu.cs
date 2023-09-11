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
        AudioManager.Instance.PlaySFX("Bouton");
        StartCoroutine(StartButtonCoroutine());
    }

    public void Quit()
    {
        AudioManager.Instance.PlaySFX("Bouton");
        StartCoroutine(QuitButtonCoroutine());
    }

    public void Credits()
    {
        AudioManager.Instance.PlaySFX("Bouton");
        menu.gameObject.SetActive(false);
        credits.gameObject.SetActive(true);
    }

    public void ReturnToMenu()
    {
        AudioManager.Instance.PlaySFX("Bouton");
        credits.gameObject.SetActive(false);
        menu.gameObject.SetActive(true);
    }

    private IEnumerator StartButtonCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Main");
    }
    
    private IEnumerator QuitButtonCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        Application.Quit();
    }
}