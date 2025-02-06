using System;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameDatabase GameDatabase { get; private set; }
    [field: SerializeField]
    public DuckManager DuckManager { get; private set; }
    
    [field: SerializeField]
    private DuckData dt;
    
    //allow to load the class when the game start and before the scene load
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Load()
    {
        //generate the database
        GameDatabase = new GameDatabase();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            DuckManager.SpawnDuck(dt);
        }
    }
}