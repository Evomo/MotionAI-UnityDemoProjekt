using System;
using System.Collections;
using System.Collections.Generic;
using MotionAI.Core.Controller;
using MotionAI.Core.Models;
using MotionAI.Core.Models.Generated;
using MotionAI.Core.POCO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ElmoEvents
{
    public OnElmoEvent squat, pushUp;
}

public class DemoMotionAIController : MotionAIController
{
    private Bodyweight _movementModel;
    
    public TMP_Text LastElementalMovement;
    
    public ElmoEvents movements = new ElmoEvents();


    //Don't forget to override! Or the events won't work
    public override void Start()
    {
        base.Start();
        Debug.Log("Starting inspector controller");

        //Initialize the controller by casting the model to the controller you wish to use
        _movementModel = GetComponent<AbstractModelComponent>() as Bodyweight;
/*
        //Once initialized you can access its members and events!

        if (_movementModel != null) {
            _movementModel.moves?.jumping_jack.onMove.AddListener(JJCallBack);
        }

        //In this particular example I want to subscribe to ALL events except duck!
        foreach (MoveHolder moveHolder in modelManager.model.GetMoveHolders()) {
            if (moveHolder.id != MovementEnum.duck) {
                moveHolder.onMove.AddListener(AllEventsCallback);
            }
        }*/
    }

    public void debugAddElmo()
    {
        ElementalMovement elmo = new ElementalMovement
        {
            typeLabel = "squat_down", typeID = ElmoEnum.squat_down, rejected = false
        };

        HandleElmo(elmo);
    }

    protected override void HandleMovement(EvoMovement msg)
    {
        msg.elmos.ForEach(HandleElmo);
    }

    private void HandleElmo(ElementalMovement elementalMovement)
    {
        if (elementalMovement.typeID == ElmoEnum.squat_down)
        {
            movements.squat.Invoke(elementalMovement);
        }
        else if (elementalMovement.typeID == ElmoEnum.pushup_down)
        {
            movements.pushUp.Invoke(elementalMovement);
        }

        LastElementalMovement.text = elementalMovement.typeLabel;
    }
}