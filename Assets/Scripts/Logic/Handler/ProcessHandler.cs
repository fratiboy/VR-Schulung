﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Class responsible for loading Assets and assigning Tasks to the Task-Manager 
public class ProcessHandler : MonoBehaviour
{
    [SerializeField] private SceneLoader sceneLoader;
    [SerializeField] private TaskManager taskManager;
    [SerializeField] private UserInterfaceManager uiManager;
    [SerializeField] private GameObject spawnPoints;
    [SerializeField] private Material closePreviewMaterial, farPreviewMaterial;
    [SerializeField] private GameObject tracheostomaCO, woman;
    private static ProcessHandler _instance;
    // Singleton
    public static ProcessHandler Instance { get { return _instance; } }

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        tracheostomaCO = Instantiate(tracheostomaCO);
        woman.GetComponent<ConnectorObject>().ForceConnect(tracheostomaCO);
        LoadScene("process_001");
    }

    // Called when all Tasks are over
    public void EndOfTasks()
    {
        uiManager.EndOfTasks();
    }
    // When a collision between two interactable objects happens, then this method gets called
    public void ReportCollision(CollisionEvent ce)
    {
        taskManager.HandleCollision(ce);
    }
    public void NextTask()
    {
        taskManager.NextTask(false);
    }

    // LoadScene is used to load a scene with an PID
    void LoadScene(string pid)
    {
        sceneLoader.LoadProcess(pid);
        taskManager.SetToolList(sceneLoader.GetToolList());
        taskManager.SetTaskList(sceneLoader.GetTaskList());
    }
    // Calls the next tasks
    public void UINextTask(string desc, bool isFirst)
    {
        uiManager.NewTask(desc, isFirst);
    }
    // Gets all Spawnpoints
    public Transform[] GetSpawnPoints() => spawnPoints.GetComponentsInChildren<Transform>();

    public TaskManager GetTaskManager() => this.taskManager;
    public Material GetClosePreviewMaterial() => this.closePreviewMaterial;
    public Material GetFarPreviewMaterial() => this.farPreviewMaterial;
    public GameObject GetCompoundObject() => this.tracheostomaCO;
}
