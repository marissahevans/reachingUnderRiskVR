using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // set up public variables for use by objects
    public static GameManager Instance;

    public Vector3 tarPos;

    public Vector3 penaltyPos;
    
    public int trial = 0;
    
    // setting up public update for trials
    public int Trial
    {
        get { return trial; }
        set { trial = value; }
    }
    
    // Setting up public update for target postion
    public Vector3 TarPos
    {
        get { return tarPos; }
        set { tarPos = value; }
    }
    
    // Setting up public update for target postion
    public Vector3 PenaltyPos
    {
        get { return penaltyPos; }
        set { penaltyPos = value; }
    }
    
    // save GameManager as a singleton on load
    void Awake()
    {
        if (Instance == null) //if the instance var has not been set
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else //if there is already a singleton of this type
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
