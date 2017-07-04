﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu( menuName = "LevelManager/Objects/Create Interactor" )]
public class InteractorDescriptor : Descriptor {
    public Descriptor[] requiredObjects;
    [TextArea( 5, 10 )]
    public string successText, failedText;

    public bool canActivate() {
        for ( int i = 0; i < requiredObjects.Length; i++ ) {
            if ( !requiredObjects[i].IsActive ) {
                DebugUI.instance.Log( failedText );
                return false;
            }
        }
        DebugUI.instance.Log( successText );
        return true;
    }
}
