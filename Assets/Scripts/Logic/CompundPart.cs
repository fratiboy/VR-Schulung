﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompundPart : InteractableObject
{
    [SerializeField] private bool taskFocus;
    // Start is called before the first frame update
    void Awake() => taskFocus = false;
    public override void OnDrop()
    {
        base.OnDrop();
        if (taskFocus)
        {
            Debug.Log("NextTAsk");
            ProcessHandler.Instance.NextTask();
            taskFocus = false;
            GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    public void SetTaskFocus(bool focus) => taskFocus = focus;
}
