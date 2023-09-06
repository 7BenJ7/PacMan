using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] 
    private Canvas menu;
    [SerializeField] 
    private Canvas hud;
    [SerializeField] 
    private Canvas credits;
    
    [SerializeField] 
    private PlayerManager pacman;
    [SerializeField]
    private Transform spawnTransform;

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
    
    public void ScoreUp(int scoreAdded)
    {
        score += scoreAdded;
        //TODO UI
    }

}