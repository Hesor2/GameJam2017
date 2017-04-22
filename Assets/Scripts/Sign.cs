using UnityEngine;
using System.Collections;
using System;

public class Sign : Interactable
{
    public string text;
    public Rect textArea;
    public GUIStyle style;

    private bool showText = false;
    public float timeShown = 5.0f;
    private float currentTime = 0.0f, executedTime = 0.0f;

    public override void Interact(GameObject interacter)
    {
        print(text);
        showText = true;
        executedTime = Time.time;
    }

    // Use this for initialization
    void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        currentTime = Time.time;

        if (executedTime != 0.0f)
        {
            if (currentTime - executedTime > timeShown)
            {
                executedTime = 0.0f;
                showText = false;
            }
        }
    }

    void OnGUI()
    {
        if (showText)
            GUI.Label(textArea, text, style);
    }
}
