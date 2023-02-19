using UnityEngine;

[CreateAssetMenu(fileName = "DataLevel", menuName = "Data/DataLevel")]
public class DataLevel : ScriptableObject
{
    public DataRecipe DataRecipe;
    public DataSpawnObjects DataSpawnObjects;
    public float TimeSpawn = 1.5f;
    public float TimeLevel = 15f;
}
