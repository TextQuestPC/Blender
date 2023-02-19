using UnityEngine;

public class ConSpawnTimer : MonoBehaviour
{
    private float timeSpawn = 2f;
    private float timeBeforeSpawn = 2f;

    public bool TimeGo { set; private get; }
    public bool SpawnNow { set; private get; }

    private void Start()
    {
        TimeGo = false;
    }

    private void Update()
    {
        if (TimeGo && !SpawnNow)
        {
            timeBeforeSpawn -= Time.deltaTime;

            if (timeBeforeSpawn <= 0)
            {
                SpawnNow = true;
                TimeForSpawn();
            }
        }
    }

    public void SetTimeSpawn(float timeSpawn)
    {
        this.timeSpawn = timeSpawn;
        timeBeforeSpawn = timeSpawn;
    }

    private void TimeForSpawn()
    {
        timeBeforeSpawn = timeSpawn;
        ManagerSpawner.Instance.TimeForSpawn();
    }
}
