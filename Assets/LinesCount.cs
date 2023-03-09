using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinesCount : MonoBehaviour
{
    public int count = 6;
    public float[] posXLines = { 5.9f, 3.5f, 1.1f, -1.1f, -3.5f, -5.9f };
    public BlenderMovement blenderMovement;
    public ManagerSpawner managerSpawner;
    public ConChoosePositionForSpawn conChoosePositionForSpawn;
    public GameObject[] lines;
    public GameObject blender;
    private void OnEnable()
    {
        SortMassiv();
    }
    public void SortMassiv()
    {
        if (count == 6)
        {
            posXLines = new float[] { -5.9f, -3.5f, -1.1f, 1.1f, 3.5f, 5.9f };
        }
        else if (count == 5)
        {
            posXLines = new float[] { -5.9f, -3.5f, -1.1f, 1.1f, 3.5f };
            lines[5].SetActive(false);
            //Destroy(lines[5]);
            conChoosePositionForSpawn.pointsSpawn[4].SetActive(false);
        }
        else if (count == 4)
        {
            posXLines = new float[] { -3.5f, -1.1f, 1.1f, 3.5f };
            Destroy(lines[0]);
            Destroy(lines[5]);
            conChoosePositionForSpawn.pointsSpawn[5].SetActive(false);
            conChoosePositionForSpawn.pointsSpawn[6].SetActive(false);
        }
        else if (count == 3)
        {
            posXLines = new float[] { -1.1f, 1.1f, 3.5f };
            Destroy(lines[0]);
            Destroy(lines[1]);
            Destroy(lines[5]);
            conChoosePositionForSpawn.pointsSpawn[0].SetActive(false);
            conChoosePositionForSpawn.pointsSpawn[5].SetActive(false);
            conChoosePositionForSpawn.pointsSpawn[6].SetActive(false);
        }
        managerSpawner.countObjectOperation = count;
        blenderMovement.positions = posXLines;
    }
}
