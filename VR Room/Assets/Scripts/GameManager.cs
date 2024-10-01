using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.Mathematics;
// From the internet. Work around for the argument exception 
#if USE_INPUT_SYSTEM_POSE_CONTROL
using PoseControl = UnityEngine.InputSystem.XR.PoseControl;
#else
using PoseControl = UnityEngine.XR.OpenXR.Input.PoseControl;
#endif

public class GameManager : MonoBehaviour
{
    
// set up public variables for use by objects
    public static GameManager Instance;

    public Vector3 tarPos;

    public Bounds penaltyPos;

    public Vector3 reachEndpt;

    public Vector3 startPos = new Vector3(-1.8F,.7F,0);

    public float tarSize = .05F;
    
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
    
    // Setting up public update for penalty postion
    public Bounds PenaltyPos
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
