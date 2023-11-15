using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SphereCountScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int SphereCount = 0;
    private TMP_Text text;

    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }

    public void Pickup()
    {
        SphereCount++;
        text.text = $"{SphereCount} / 4";
        if (SphereCount >= 4)
        {
            text.text = "You Win! !";
        }
    }
}
