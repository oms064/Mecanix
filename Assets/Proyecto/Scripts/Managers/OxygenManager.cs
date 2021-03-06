﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenManager : MonoBehaviour {
    public static OxygenManager instance;
    public OxygenDescriptor descriptor;
    private bool isActive = false;
    public DoorDescriptor doorTrigger;
    public EventBehaviour[] events;

    private void Awake() {
        instance = this;
    }

    private void Start() {
        doorTrigger.SceneLoadingFinish += OnSceneStart;
    }

    private void Update() {
        if(isActive)
            descriptor.Set( Time.deltaTime );
    }

    private void OnSceneStart() {
        isActive = true;
        descriptor.Begin();
        doorTrigger.SceneLoadingFinish -= OnSceneStart;
        //DebugUI.instance.Log( "El oxígeno empezó a drenarse!" );
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].StartEvent();
        }
    }

    public void Fix() {
        isActive = false;
        DebugUI.instance.Log( "El oxígeno dejó de fugarse" );
        for ( int i = 0; i < events.Length; i++ ) {
            events[i].EndEvent();
        }
    }

}
