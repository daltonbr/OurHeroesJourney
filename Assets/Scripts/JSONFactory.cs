using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using LitJson;

// list of JSON file with path extension
// Only NarrativeManager should be able to use this script
// Take in scene number, output NarrativeEvent - Black Box (incapsulation principle)
// Validation and Exception Handling

namespace JSONFactory
{
    public class JSONAssembly        
    {
        private static Dictionary<int, string> _resourceList = new Dictionary<int, string>
        {
            {1, "/Resources/Dialogues/Event1.json" }            
        };
    }

}

