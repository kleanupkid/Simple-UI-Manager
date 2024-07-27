using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIProperties
{
    public string componentName;
    
    public GameObject uiLayer;
    
    [HideInInspector]
    public TextMeshProUGUI textLayer;
    [HideInInspector]
    public RectTransform rectTransform;

    [HideInInspector] public Button button;

    [HideInInspector] public Vector2 startingPosition;
}
