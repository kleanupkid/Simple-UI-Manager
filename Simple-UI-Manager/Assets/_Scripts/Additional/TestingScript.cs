using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingScript : MonoBehaviour
{
    private int _num;
    private bool _isOpen;
    private void Start()
    {
        UIGlobalManager.ListenerToButton?.Invoke("Toggle Image Button",ToggleImage);
        UIGlobalManager.ListenerToButton?.Invoke("Update Text Button",UpdateText);
        UIGlobalManager.ListenerToButton?.Invoke("Display Prompt Button",DisplayPrompt);

        _isOpen = false;
    }
    
    private void ToggleImage()
    {
        if (!_isOpen)
        {
            UIGlobalManager.ToggleMenu?.Invoke("Image",true);
            _isOpen = true;
        }

        else if (_isOpen)
        {
            UIGlobalManager.ToggleMenu?.Invoke("Image",false);
            _isOpen = false;
        }
        
    }

    private void UpdateText()
    {
        _num++;
        UIGlobalManager.UpdateTextLayer?.Invoke("Text",_num);
    }

    private void DisplayPrompt()
    {
        UIGlobalManager.DisplayPromptLayer?.Invoke("Prompt",2f);
    }

}
