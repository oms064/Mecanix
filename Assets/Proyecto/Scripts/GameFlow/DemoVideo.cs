﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoVideo : MonoBehaviour {
    public float idleTime;
    private float timeS, time;
    public SceneLoaderScriptable sceneManager;
    // Use this for initialization
    void Start() {
        timeS = idleTime * 60;
        time = 0;
        sceneManager.OnDemoVideo = false;
    }

    // Update is called once per frame
    void FixedUpdate() {
        time += Time.fixedDeltaTime;
        if ( Input.anyKeyDown ) {
            time = 0;
        }
        if ( time >= timeS ) {
            sceneManager.StartSelectorScreen();
            sceneManager.OnDemoVideo = true;
        }

    }

    private void Update() {
        if ( Input.GetKeyUp( KeyCode.R ) ) {
            sceneManager.StartMainMenu();
        }
    }
}
