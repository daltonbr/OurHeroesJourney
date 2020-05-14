using UnityEngine;

public class AtlasManager : MonoBehaviour, IManager
{
    public static Sprite[] sprites;
    public ManagerState CurrentState { get; private set; }

    public void BootSequence()
    {
        Debug.Log($"{GetType().Name} is booting up");

        sprites = Resources.LoadAll<Sprite>("EventAtlas");
        CurrentState = ManagerState.Completed;

        Debug.Log($"{GetType().Name} status = {CurrentState} ");
    }

    public Sprite LoadSprite(string spriteName)
    {
        foreach (Sprite s in sprites)
        {
            if (s.name == spriteName) { return s; }
        }

        return null;
    }
}
