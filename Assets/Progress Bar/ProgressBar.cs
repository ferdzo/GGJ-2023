using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI naturePointsText;
    public TextMeshProUGUI humanPointsText;

    public float naturePoints;
    public float humanPoints;
    public float value;

    // Start is called before the first frame update
    public void SetProgressValue()
    {
        float totalPoints = naturePoints + humanPoints;
        value = naturePoints / totalPoints;
        slider.value = naturePoints / totalPoints;
        naturePointsText.text = Convert.ToString(Math.Round(naturePoints));
        humanPointsText.text = Convert.ToString(Math.Round(humanPoints));

    }

    void Update()
    {
        CalculatePoints();
        SetProgressValue();
    }

    void CalculatePoints()
    {
        naturePoints = 0;
        humanPoints = 0;

        DataValue[] values = GameObject.FindObjectsOfType<DataValue>();

        foreach (DataValue value in values)
        {
            if (value.tiletype == DataValue.Tile_type.Player)
            {
                humanPoints += value.points;
            }
            else if (value.tiletype == DataValue.Tile_type.Nature)
            {
                naturePoints += value.points;
            }
        }
    }
}