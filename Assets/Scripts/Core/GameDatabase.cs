using UnityEngine;

public class GameDatabase
{
    public DuckData[] Ducks { get; private set; }

    // Permet de récuperer les objet dans les ressources
    public GameDatabase()
    {
        Ducks = Resources.LoadAll<DuckData>("Ducks");
    }
}
