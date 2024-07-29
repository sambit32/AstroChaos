using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private IntegerVariable score;

    private void Update()
    {
        scoreText.text = score.value.ToString();
    }

}
