using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;

    void OnEnable() //gets called everytime a gameobject is enabled instead of at the start of game
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText()
    {
        roundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.5f); //wait one second for animations to finish before counting up

        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(0.04f); //wait for 0.5 seconds before increasing the rounds
        }

    }

}
