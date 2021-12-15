﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ConnectorObject : InteractableObject
{
    public bool connectorActive = false;
    public GameObject preview = null;
    [SerializeField] private GameObject anchorPoint = null;

    public void Connect(GameObject connectible)
    {
        if (!connectible.GetComponent<InteractableObject>().GetIsGrabbed() && connectorActive && this.GetIsGrabbed())
        {
            connectible.transform.parent = this.anchorPoint.transform;
            connectible.GetComponent<Rigidbody>().isKinematic = true;
            connectible.GetComponent<Collider>().enabled = false;
            connectible.GetComponent<InteractableObject>().SetGrabbable(false);
            connectible.transform.localPosition = new Vector3(0, 0, 0);
            connectible.transform.localEulerAngles = new Vector3(0, 0, 0);
            Debug.Log(connectible.name + "  connects to  " + this.name);
            ProcessHandler.Instance.NextTask();
            this.connectorActive = false;
            DestroyPreview();
            Destroy(connectible.GetComponent<Connectible>());
            Destroy(this);
        }
    }

    public void Preview(GameObject prefab)
    {
        if (preview == null)
        {
            preview = Instantiate(prefab);
            preview.GetComponent<InteractableObject>().SetGrabbable(false);
            DestroyImmediate(preview.GetComponent<XRGrabInteractable>());
            foreach (Component comp in preview.GetComponents<Component>())
            {
                if (!(comp is Transform))
                {
                    Destroy(comp);
                }
            }
            foreach (Renderer renderer in preview.GetComponentsInChildren<Renderer>())
            {
                renderer.material = ProcessHandler.Instance.GetPreviewMaterial();
            }
            preview.transform.parent = this.anchorPoint.transform;
            preview.transform.localPosition = new Vector3(0, 0, 0);
            preview.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
    }
    public void DestroyPreview()
    {
        if (preview != null) Destroy(preview);
    }
    public Vector3 GetAnchorPosition()
    {
        return anchorPoint.transform.position;
    }
}
