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
        private const string PathToDialogueScene0 = "/Resources/Dialogues/Event1.json";

        private static Dictionary<int, string> _resourceList = new Dictionary<int, string>
        {
            {0, $"{Application.dataPath}/{PathToDialogueScene0}"}
        };

        public static NarrativeEvent RunJSONFactoryForScene(int sceneNumber)
        {
            string resourcePath = PathForScene(sceneNumber);

            if (IsValidJSON(resourcePath))
            {
                string jsonString = File.ReadAllText(resourcePath);
                NarrativeEvent narrativeEvent = JsonMapper.ToObject<NarrativeEvent>(jsonString);
                return narrativeEvent;
            }
            else
            {
                throw new Exception("The JSON is not valid, please check the schema and file extension.");
            }
        }

        private static string PathForScene(int sceneNumber)
        {
            string resoucePathResult;

            if (_resourceList.TryGetValue(sceneNumber, out resoucePathResult))
            {
                return _resourceList[sceneNumber];
            }
            else
            {
                throw new Exception("The scene number you provide is not in the resource list. Please check the JSONFactory namespace.");
            }
        }

        private static bool IsValidJSON(string path)
        {
            // TODO: we can improve this validation
            return (Path.GetExtension(path) == ".json");
        }

    }
}

