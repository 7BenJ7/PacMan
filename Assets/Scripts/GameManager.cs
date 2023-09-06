using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Canvas")]
    [SerializeField] 
    private Canvas menu;
    [SerializeField] 
    private Canvas hud;
    [SerializeField] 
    private Canvas credits;
    
    [Header("Pacman")]
    [SerializeField] 
    private PlayerManager pacman;
    [SerializeField]
    private Transform spawnTransform;

    [Header("HUD")]
    [SerializeField] 
    private GameObject hearts;
    [SerializeField] 
    private TMP_Text scoreText;

    public int score;
    public int life;

    private void Awake()
    {
        if(Instance != null) Destroy(Instance.gameObject);
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        hud.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
    }

    public void StartGame()
    {
        //TODO DIsparition menu
        menu.gameObject.SetActive(false);
        credits.gameObject.SetActive(false);
        hud.gameObject.SetActive(true);
        Spawn();
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
    
    public void Spawn()
    {
        PlayerManager pacmanSpawned = Instantiate(pacman, spawnTransform.position, Quaternion.identity);
        pacmanSpawned.gameObject.SetActive(true);
    }

    public void TakeDamage()
    {
        //if(hearts.transform.GetChildren()
    }
    
    public void ScoreUp(int scoreAdded)
    {
        Debug.Log("score up");
        score += scoreAdded;
        scoreText.text = "Score : \n" + score;
    }

}