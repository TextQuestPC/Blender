using UnityEngine;

public class ManagerStates : Singleton<ManagerStates>
{
    public void ChangeStateGame(TypeStateGame stateGame)
    {
        if (stateGame == TypeStateGame.Game)
        {
            ChangeCanSwipe(true);
            ChangeCanSpawnFruit(true);
            ManagerObjects.Instance.GoFruits();
            ManagerTime.Instance.TimerGo();
        }
        else if (stateGame == TypeStateGame.LoadingLevel || stateGame == TypeStateGame.Pause)
        {
            ChangeCanSwipe(false);
            ChangeCanSpawnFruit(false);
            ManagerObjects.Instance.StopFallObjects();
            ManagerTime.Instance.TimerStop();
        }
    }

    private void ChangeCanSwipe(bool canSwipe)
    {
        ManagerSwipeTap.Instance.ChangeCanSwipeTap(canSwipe);
    }

    private void ChangeCanSpawnFruit(bool canSpawn)
    {
        ManagerSpawner.Instance.SetCanSpawn(canSpawn);
    }
}
