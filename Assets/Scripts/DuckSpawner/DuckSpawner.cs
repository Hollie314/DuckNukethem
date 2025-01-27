using System;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;

public class DuckSpawner : MonoBehaviour
{
    DuckInFile duckInFile;

    public void SpawnDuck(GameObject duck)
    {
        Instantiate(duck);
    }
}
