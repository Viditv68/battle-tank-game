using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class AchievementSystem : MonoBehaviour
{
    [SerializeField]
    private Text bulletsFiredByPlayer;
    [SerializeField]
    private Text enemiesKilldUI;

    [SerializeField]
    private Animator achievementAnimator;

    private int enemiesKilled;
    private int bulletsFired;

    private int maxScore;
    private bool displayScore;

    private void Start()
    {
        enemiesKilled = 0;
        bulletsFired = 0;
        EventService.Instance.onFire += GameUIOnFire;
        EventService.Instance.onEnemyDeath += GameUIEnemyDeath;
        maxScore = PlayerPrefs.GetInt("enemiesKilled");
        displayScore = true;
    }

    private void GameUIEnemyDeath()
    {
        enemiesKilled++;
        enemiesKilldUI.text = "Killed: " + enemiesKilled;
        ChecForKillAchievements(enemiesKilled, displayScore);
    }

    private void GameUIOnFire()
    {
        bulletsFired++;
        bulletsFiredByPlayer.text = "Bullets: " + bulletsFired;
        
    }

    private void ChecForKillAchievements(int enemiesKilled, bool displayScore)
    {
        
        if(enemiesKilled > maxScore && displayScore)
        {
            PlayerPrefs.SetInt("enemiesKilled", enemiesKilled);
            achievementAnimator.GetComponentInChildren<Text>().text = "New Score: " + enemiesKilled;
            achievementAnimator.SetBool("PushDown", true);
            displayScore = false;
            StartCoroutine(PushUp());
        }
        
    }

    IEnumerator PushUp()
    {
        yield return new WaitForSeconds(2f);
        achievementAnimator.SetBool("PushDown", false);
    }

 
}
