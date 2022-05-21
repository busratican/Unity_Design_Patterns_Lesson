using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class Level : MonoBehaviour
{
    [SerializeField] int pointsPerLevel = 200;
    [SerializeField] UnityEvent onLevelUp;
    int experiencePoints = 0;

    /*public delegate void CallbackType();
    public event CallbackType onLevelUpAction;*/

    public event Action onLevelUpAction;
    //pass paramater like Action<float> onLevelUpAction;
    
    IEnumerator Start()
    {
        while(true)
        {
            yield return new WaitForSeconds(.2f);
            GainExperience(10);
        }
       
    } 

    public void GainExperience(int points)
    {
        int level = GetLevel();
        experiencePoints += points;
        if(GetLevel() > level)
        {
            onLevelUp.Invoke();
            if(onLevelUpAction != null)
            {
                onLevelUpAction();
            }
        }
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    public int GetLevel()
    {
        return experiencePoints / pointsPerLevel;
    }
}
