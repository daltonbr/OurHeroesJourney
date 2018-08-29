using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtlasManager : MonoBehaviour, IManager
{
    public static Sprite[] sprites;
    public ManagerState CurrentState { get; private set; }

    public void BootSequence()
    {
        Debug.Log(string.Format("{0} is booting up", GetType().Name));

        sprites = Resources.LoadAll<Sprite>("EventAtlas");
        CurrentState = ManagerState.Completed;

        Debug.Log(string.Format("{0} status = {1] ", GetType().Name, CurrentState));
    }

    public static Sprite LoadSprite(string spriteName)
    {
        foreach (Sprite s in sprites)
        {
            if (s.name == spriteName) { return s; }
        }

        return null;
    }
}
