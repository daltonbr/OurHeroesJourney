using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONFactory;

public class Test : MonoBehaviour
{
	
	void Start ()
    {
        NarrativeEvent testEvent = JSONAssembly.RunJSONFactoryForScene(1);
        Debug.Log(testEvent.dialogues[0].characterType);
	}
	
}
