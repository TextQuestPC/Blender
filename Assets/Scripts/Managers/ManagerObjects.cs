using System.Collections.Generic;

public class ManagerObjects : Singleton<ManagerObjects>
{
    private List<Fruit> fruits = new List<Fruit>();
    private List<Damager> damagers = new List<Damager>();
    private List<BonusTime> bonusesTime = new List<BonusTime>();

    public void AddFruit(Fruit fruit)
    {
        fruits.Add(fruit);
    }

    public void AddDamager(Damager damager)
    {
        damagers.Add(damager);
    }

    public void AddBonusTime(BonusTime bonusTime)
    {
        bonusesTime.Add(bonusTime);
    }

    /// <summary>
    /// Останавливает движение Fruit на время паузы
    /// </summary>
    public void StopFallObjects()
    {
        if(fruits.Count > 0)
        {
            foreach (var fruit in fruits)
            {
                fruit.gameObject.SetActive(false);
            }
        }

        if (damagers.Count > 0)
        {
            foreach (var damager in damagers)
            {
                damager.gameObject.SetActive(false);
            }
        }

        if(bonusesTime.Count > 0)
        {
            foreach (var bonusTime in bonusesTime)
            {
                bonusTime.gameObject.SetActive(false);
            }
        }
    }

    public void GoFruits()
    {
        if(fruits.Count > 0)
        {
            foreach (var fruit in fruits)
            {
                fruit.gameObject.SetActive(true);
            }
        }

        if (damagers.Count > 0)
        {
            foreach (var damager in damagers)
            {
                damager.gameObject.SetActive(true);
            }
        }

        if (bonusesTime.Count > 0)
        {
            foreach (var bonusTime in bonusesTime)
            {
                bonusTime.gameObject.SetActive(true);
            }
        }
    }

    /// <summary>
    /// Удалить из списка и уничтожить Fruit
    /// </summary>
    /// <param name="fruit"></param>
    public void DestroyFruit(Fruit fruit)
    {
        fruits.Remove(fruit);
        fruit.DestoyMe();
    }

    public void DestroyDamager(Damager damager)
    {
        damagers.Remove(damager);
        damager.DestoyMe();
    }

    public void DestroyBonusTime(BonusTime bonusTime)
    {
        bonusesTime.Remove(bonusTime);
        bonusTime.DestoyMe();
    }

    /// <summary>
    /// Уничтожить Fruit после завершение уровня
    /// </summary>
    public void DestroyAllObjects()
    {
        if(fruits.Count > 0)
        {
            for (int i = 0; i < fruits.Count; i++)
            {
                Fruit fruit = fruits[i];
                fruits[i] = null;
                fruit.DestoyMe();
            }
        }

        fruits.Clear();

        if (damagers.Count > 0)
        {
            for (int i = 0; i < damagers.Count; i++)
            {
                Damager damager = damagers[i];
                damagers[i] = null;
                damager.DestoyMe();
            }
        }

        damagers.Clear();

        if (bonusesTime.Count > 0)
        {
            for (int i = 0; i < bonusesTime.Count; i++)
            {
                BonusTime bonusTime = bonusesTime[i];
                bonusesTime[i] = null;
                bonusTime.DestoyMe();
            }
        }

        bonusesTime.Clear();
    }
}
