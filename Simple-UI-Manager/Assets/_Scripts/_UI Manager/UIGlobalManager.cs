using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIGlobalManager : MonoBehaviour
{
    public static UIGlobalManager Instance { get; private set; }
    
    public UIProperties[] uIProperties;
    [SerializeField] private Vector2 endValue;
    

    [Tooltip("Action to be called when you need to update a text value")]
    public static Action<string,float> UpdateTextLayer;
    public static Action<string,float> DisplayPromptLayer;
    public static Action<string, float> DisplayPromptLayerWithTweening;
    public static Action<string, bool> ToggleMenu;
    public static Action<string,UnityAction> ListenerToButton;
    public static Action<string, float> UpdateSliderValue;

    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        foreach (UIProperties layer in uIProperties)
        {
            layer.rectTransform = layer.uiLayer.GetComponent<RectTransform>();
            layer.textLayer = layer.uiLayer.GetComponent<TextMeshProUGUI>();
            layer.startingPosition = layer.rectTransform.position;
            layer.button = layer.uiLayer.GetComponent<Button>();
        }
        
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        UpdateTextLayer += UpdateText;
        DisplayPromptLayer += DisplayPrompts;
        DisplayPromptLayerWithTweening += DisplayPromptsWithTween;
        ToggleMenu += OpenMenu;
        ListenerToButton += AddListenerToButton;
        UpdateSliderValue += UpdateSlider;
    }

    private void OnDisable()
    {
        UpdateTextLayer -= UpdateText;
        DisplayPromptLayer -= DisplayPrompts;
        DisplayPromptLayerWithTweening -= DisplayPromptsWithTween;
        ToggleMenu -= OpenMenu;
        ListenerToButton -= AddListenerToButton;
        UpdateSliderValue -= UpdateSlider;
    }

    // Function to be called when you need to update a text value
    [Tooltip("Function to be called when you need to update a text value")]
    private void UpdateText(string textName, float value)
    {
        UIProperties textLayer = Array.Find(uIProperties, textLayer => textLayer.componentName == textName);

        if (textLayer == null)
        {
            return;
        }

        textLayer.textLayer.text = value.ToString("0");
    }
    
    
    // Function to be called when you need to display a prompt
    private void DisplayPrompts(string promptName,float timeToStay)
    {
        UIProperties promptLayer = Array.Find(uIProperties, promptLayer => promptLayer.componentName == promptName);

        if (promptLayer == null)
        {
            return;
        }
        
        // If you want to simply display the layer in the given position, toggle this
        StartCoroutine(CDisplayForSeconds(promptLayer.uiLayer, timeToStay));
    }
    
    // Function to be called when you need to display a prompt and move it to a particular position
    
    private void DisplayPromptsWithTween(string promptName,float timeToStay)
    {
        UIProperties promptLayer = Array.Find(uIProperties, promptLayer => promptLayer.componentName == promptName);

        if (promptLayer == null)
        {
            return;
        }
        
        // If you want to move the layer to a particular position, toggle this
        StartCoroutine(CShowPromptForSeconds(promptLayer.uiLayer,promptLayer.rectTransform,promptLayer.startingPosition,timeToStay));
    }

    // Function to be called when you need to display a menu
    private void OpenMenu(string menuName,bool value)
    {
        UIProperties menu = Array.Find(uIProperties, menu => menu.componentName == menuName);
        menu?.uiLayer.SetActive(value);
    }
    
    // Function to be called to add a button listener

    private void AddListenerToButton(string buttonName,UnityAction functionName)
    {
        UIProperties button = Array.Find(uIProperties, button => button.componentName == buttonName);
        button?.button.onClick.AddListener(functionName);
    }
    
    // Function to be called to update slider value

    private void UpdateSlider(string sliderName,float value)
    {
        UIProperties slider = Array.Find(uIProperties, slider => slider.componentName == sliderName);
        slider.uiLayer.GetComponent<Slider>().value = value;
    }
    
    
    // Coroutine to show the necessary prompt for X seconds
    #region Couroutines
    // Coroutines
    
    // Simple Coroutine without position

    IEnumerator CDisplayForSeconds(GameObject prompt, float timeToStay)
    {
        prompt.SetActive(true);
        yield return new WaitForSeconds(timeToStay);
        prompt.SetActive(false);
        yield break;
    }
    
    // Simple Coroutine with rectTransform position
    // Requires DG Tweening
    IEnumerator CShowPromptForSeconds(GameObject prompt,RectTransform rectTransform,Vector2 value,float timeToStay)
    {
        prompt.SetActive(true);
        rectTransform.DOAnchorPos(endValue, 0.2f);
        yield return new WaitForSeconds(timeToStay);
        
        rectTransform.DOAnchorPos(value, 0.2f);
        prompt.SetActive(false);
        yield break;
    }

    // // Coroutine to show the move and add a transition to the prompt
    // IEnumerator CPromptTransition(RectTransform prompt)
    // {
    //     prompt.DOAnchorPos(endValue, 0.2f);
    //     yield return new WaitForEndOfFrame();
    // }
    

    #endregion
    
    
}
