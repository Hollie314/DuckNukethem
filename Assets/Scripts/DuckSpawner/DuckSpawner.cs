using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using Object = System.Object;
public class DuckSpawner : MonoBehaviour
{
    DuckInFile duckInFile;
    Boolean canSpawn = true;
    public int duckNumber;
    public void SpawnDuck(GameObject duck)
    {
        if (canSpawn == true && duckNumber<=4)
        {
            Instantiate(duck);
            canSpawn = false;
            duckNumber++;
            StartCoroutine(canISpawn());
        }
        IEnumerator canISpawn()
        {
            yield return new WaitForSeconds(1f);
            canSpawn = true;
        }
    }
}
