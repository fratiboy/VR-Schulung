using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Manages the UI
public class UserInterfaceManager : MonoBehaviour
{
    public CorkboardHandler handler;
    // New Tasks are displayed in this method
    public void NewTask(string taskdescription, bool isFirst) 
    {
        if (isFirst) handler.FirstTask(taskdescription);
        else handler.NewTask(taskdescription);
    }
    // When all tasks are over
    public void EndOfTasks()
    {
        handler.FinishTask();
    }
}
