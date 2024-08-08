using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Mathematics;

public class GameManager : MonoBehaviour
{
    
// set up public variables for use by objects
    public static GameManager Instance;

    public Vector3 tarPos;

    public Vector3 penaltyPos;

    public Vector3 reachEndpt;
    
    public int trial = 0;

    public int block = 0;
    public List<int> penMode = new List<int> { 3, 2, 1, 3, 2, 1 };

    public int points = 0;
    
    // setting up public update for trials
    public int Trial
    {
        get { return trial; }
        set { trial = value; }
    }
    
    // setting up public update for blocks
    public int Block
    {
        get { return block; }
        set { block = value; }
    }
    
    // setting up public update for points
    public int Points
    {
        get { return points; }
        set { points = value; }
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
    
    // Setting up public update for reach postion
    public Vector3 ReachEndpt
    {
        get { return reachEndpt; }
        set { reachEndpt = value; }
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
