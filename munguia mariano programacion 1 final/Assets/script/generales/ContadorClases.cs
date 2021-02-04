using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorClases : MonoBehaviour
{ 
    
    public void QuestDone()
    {
        int CountQuest = 0;

        if (PlayerPrefs.HasKey("QuestsDone"))
        {
            CountQuest = PlayerPrefs.GetInt("QuestsDone");
        }
        CountQuest += 1;
        PlayerPrefs.SetInt("QuestsDone", CountQuest);
        PlayerPrefs.Save();
    }

    public bool BossQuest()
    {
        bool BossQuestDone = false;
        if (PlayerPrefs.HasKey("QuestsDone"))
        {
            if (PlayerPrefs.GetInt("QuestsDone") >= 3)
            {
                BossQuestDone = true;
            }
        }
        return BossQuestDone;
    }
    //SaveLevel("Nivel1")                 
    public void SaveLevel(string level)
    {
        PlayerPrefs.SetString(level, level);
    }

    //GetLevel("Level1")
    public bool GetLevel(string level)
    {
        bool isDoneQuest = false;
        if (PlayerPrefs.HasKey(level))
        {
            isDoneQuest = true;
        }
        return isDoneQuest;
    }

}
