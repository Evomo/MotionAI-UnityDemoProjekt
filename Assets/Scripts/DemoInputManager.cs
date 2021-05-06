using System.Collections;
using System.Collections.Generic;
using MotionAI.Core.Controller;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Color;

public class DemoInputManager : MonoBehaviour
{
    
    public Button SquatIndicator;
    public Button PushUpIndicator;
    
    [HideInInspector] public MotionAIManager maim;

    private void Start()
    {
        maim = GetComponent<MotionAIManager>();
    }
    IEnumerator TriggerButtonCoroutine(Button button)
    {
        button.image.color = Color.green;
        
        yield return new WaitForSeconds(1);
        
        button.image.color = Color.gray;
    }
    public void TriggerSquatIndicator()
    {
        StartCoroutine(TriggerButtonCoroutine(SquatIndicator));
    }
    
    public void TriggerPushUpIndicator()
    {
        StartCoroutine(TriggerButtonCoroutine(PushUpIndicator));
    }
    
    public void ScanForMovesense()
    {
        Debug.Log("ScanForMovesense");
    }
    
    public void StartTracking()
    {
        Debug.Log("StartTracking");
        if (!maim.isTracking) {
            maim.StartTracking();
        }
    }
    
    public void StopTracking()
    {
        Debug.Log("StopTracking");
        if (maim.isTracking)
        {
            maim.StopTracking();
        }
    }
}
