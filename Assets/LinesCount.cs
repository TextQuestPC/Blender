using UnityEngine;

public class LinesCount : Singleton<LinesCount>
{
    //public float[] posXLines = { 5.9f, 3.5f, 1.1f, -1.1f, -3.5f, -5.9f };
    [SerializeField] private GameObject[] lines;

    private int countLines = 6;

    public int GetCountLines { get => countLines; }
    

    public void Init(int countLines)
    {
        this.countLines = countLines;

        for (int i = 0; i < lines.Length; i++)
        {
            lines[i].gameObject.SetActive(i < countLines);            
        }

        //if (this.countLines == 6)
        //{
        //    posXLines = new float[] { -5.9f, -3.5f, -1.1f, 1.1f, 3.5f, 5.9f };
        //}
        //else if (this.countLines == 5)
        //{
        //    posXLines = new float[] { -5.9f, -3.5f, -1.1f, 1.1f, 3.5f };
        //    lines[5].SetActive(false);
        //    //Destroy(lines[5]);
        //    conChoosePositionForSpawn.pointsSpawn[4].SetActive(false);
        //}
        //else if (this.countLines == 4)
        //{
        //    posXLines = new float[] { -3.5f, -1.1f, 1.1f, 3.5f };
        //    Destroy(lines[0]);
        //    Destroy(lines[5]);
        //    conChoosePositionForSpawn.pointsSpawn[5].SetActive(false);
        //    conChoosePositionForSpawn.pointsSpawn[6].SetActive(false);
        //}
        //else if (this.countLines == 3)
        //{
        //    posXLines = new float[] { -1.1f, 1.1f, 3.5f };
        //    Destroy(lines[0]);
        //    Destroy(lines[1]);
        //    Destroy(lines[5]);
        //    conChoosePositionForSpawn.pointsSpawn[0].SetActive(false);
        //    conChoosePositionForSpawn.pointsSpawn[5].SetActive(false);
        //    conChoosePositionForSpawn.pointsSpawn[6].SetActive(false);
        //}
        //managerSpawner.countObjectOperation = this.countLines;
        //blenderMovement.positions = posXLines;
    }

    public float GetPositionLine(int numberLine)
    {
        return lines[numberLine].transform.position.x;
    }
}
