**What is the current behavior?**

DialogueRunner.SetProject( project ); does not work on android and iOS using IL2CPP.
It fails with error:
```
ExecutionEngineException: Attempting to call method 'System.Func`1[[System.Single, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]::.ctor' for which no ahead of time (AOT) code was generated.
10-04 01:27:38.707 17240 17265 E Unity   :   at System.Delegate.CreateDelegate (System.Type type, System.Object firstArgument, System.Reflection.MethodInfo method, System.Boolean throwOnBindFailure, System.Boolean allowClosed) [0x00000] in <00000000000000000000000000000000>:0 
10-04 01:27:38.707 17240 17265 E Unity   :   at System.Delegate.CreateDelegate (System.Type type, System.Reflection.MethodInfo method) [0x00000] in <00000000000000000000000000000000>:0 
10-04 01:27:38.707 17240 17265 E Unity   :   at Yarn.Unity.ActionManager.FindAllActions (System.Collections.Generic.IEnumerable`1[T] assemblyNames) [0x00000] in <00000000000000000000000000000000>:0 
10-04 01:27:38.707 17240 17265 E Unity   :   at Yarn.Unity.DialogueRunner.SetProject (Yarn.Unity.YarnProject newProject) [0x00000] in <00000000000000000000000000000000>:0 
```

**Please provide the steps to reproduce, and if possible a minimal demo of the problem**:

1. Create a new Unity Project in Unity 2021.3.8f1
2. Add Yarn Spinner 2.2.1 with Package Manager
3. Make sure Target Platform is Android
4. Go to Player Settings and set Scripting Backend for Android to IL2CPP
5. Enter a package name for Android Builds: e.g: "com.DefaultCompany.YarnSpinnerAOTRepro"
6. Enter a bundle identifier for iOS Builds: e.g: "com.DefaultCompany.YarnSpinnerAOTRepro"
7. Create a new gameObject
8. Add DialogueRunner and this script to it:
```
using UnityEngine;
using Yarn.Unity;

public class Repro : MonoBehaviour
{
    public YarnProject Project;
    
    void Start()
    {
        var dialogueRunner = GetComponent<DialogueRunner>();
        dialogueRunner.SetProject(Project);
        dialogueRunner.StartDialogue("Start");
    }
}
```
9. Create a new Yarn Project
10. Create a new Yarn Script with a node titled "Start"
11. Assign the Yarn Script to the Yarn Project.
12. Assign the Yarn Project to Repro.cs script in the inspector.
13. Save Scene
14. Make a build.
15. Install on phone and use something like adb logcat or (console.app on iOS) to see error in console. (Searching for "ExecutionEngineException" should take you right too it.)

**What is the expected behavior?**

No error in console. I should be able to call DialogueRunner.StartDialogue("Start"); without getting "DialogueException: Cannot load node Start: No nodes have been loaded." error.

**Please tell us about your environment:**
  
  - Yarn Spinner Version: 2.2.1
  - Unity Version: 2021.3.8f1

**Other information** 

Error reproduced using Huawei P20 lite running Android 9 and iPhone Pro Max 13 running iOS 16
Repro project is available for download here: https://github.com/johste93/YarnSpinnerAOTIssueRepro
