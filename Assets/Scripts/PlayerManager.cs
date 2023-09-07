using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    private void Awake()
    {
        if(Instance != null) Destroy(Instance.gameObject);
        Instance = this;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Instance.ScoreUp(10);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        GameManager.Instance.TakeDamage();
    }

}