using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Repro : MonoBehaviour
{
    public YarnProject Project;
    
    void Start()
    {
        var dialogueRunner = GetComponent<DialogueRunner>();
        //dialogueRunner.SetProject(Project);
        dialogueRunner.StartDialogue("Start");
    }
}
