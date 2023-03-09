using System.Collections;
using UnityEngine;

public class ManagerSpawner : Singleton<ManagerSpawner>
{
    [SerializeField] private ConChoosePositionForSpawn conChoosePosition;
    [SerializeField] private ConChooseFruitForSpawn conChooseFruit;
    [SerializeField] private ConSpawnTimer conSpawnTimer;
    [SerializeField] private ConSpawn conSpawn;

    private int countBeforeDoubleSpawn = 0;
    private int countBeforeTripleSpawn = 3;

    /// <summary>
    /// Установить Objects, которые будет спауниться на уровне
    /// </summary>
    /// <param name="dataRecipe"></param>
    public void SetDataSpawn(DataLevel dataLevel)
    {
        conSpawnTimer.SetTimeSpawn(dataLevel.TimeSpawn);
        conChooseFruit.SetDataSpawn(dataLevel.DataSpawnObjects);

        CountDoubleSpawn();
        CreateObjectsInAllLines();
    }

    /// <summary>
    /// Счётчик времени до спауна включается/отключается
    /// </summary>
    public void SetCanSpawn(bool value)
    {
        conSpawnTimer.TimeGo = value;
    }

    /// <summary>
    /// Пришло время для spawn
    /// </summary>
    public void TimeForSpawn()
    {
        if (countBeforeDoubleSpawn > 0)
        {
            countBeforeDoubleSpawn--;

            CreateObject();
        }
        else
        {
            if (countBeforeTripleSpawn > 0)
            {
                countBeforeTripleSpawn--;
                DoubleSpawn();
            }
            else
            {
                countBeforeTripleSpawn = 3;
                TripleSpawn();
            }

            CountDoubleSpawn();
        }
    }

    public void CreateObjectsInAllLines()
    {
        for (int i = 0; i < LinesCount.Instance.GetCountLines; i++)
        {
            CreateObject(i);
        }
    }

    public void EndGame()
    {
        StartCoroutine(CoSpawnFruits());
    }

    private IEnumerator CoSpawnFruits()
    {
        while (true)
        {
            yield return new WaitForSeconds(.05f);
            CreateObject();
        }
    }

    private void DoubleSpawn()
    {
        CreateObject();
        CreateObject();
    }

    private void TripleSpawn()
    {
        int noSpawnLine = Random.Range(0, 3);

        for (int i = 0; i < LinesCount.Instance.GetCountLines; i++)
        {
            if (i != noSpawnLine)
            {
                CreateObject(i);
            }
        }
    }

    private void CreateObject(int numberLine = -1)
    {
        GameObject newObj = conChooseFruit.GetObjectForSpawn();
        Vector3 position = conChoosePosition.GetPosition(numberLine);
        conSpawn.SpawnObject(newObj, position);

        conSpawnTimer.SpawnNow = false;
    }

    private void CountDoubleSpawn()
    {
        countBeforeDoubleSpawn = Random.Range(2, 4);
    }
}
