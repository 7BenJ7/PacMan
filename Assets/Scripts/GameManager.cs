using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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
        
    }

    private void StartGame()
    {
        //TODO DIsparition menu
        Spawn();
    }
    
    public void ScoreUp(int scoreAdded)
    {
        score += scoreAdded;
        //TODO UI
    }

    public void Spawn()
    {
        
    }
}