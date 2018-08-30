using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AtlasManager))]
[RequireComponent(typeof(AnimationManager))]
public class MasterManager : MonoBehaviour
{
    private List<IManager> _managerList = new List<IManager>();

    public static AtlasManager AtlasManager { get; private set; }
    public static AnimationManager AnimationManager { get; private set; }

    private void Awake()
    {
        AtlasManager = GetComponent<AtlasManager>();
        AnimationManager = GetComponent<AnimationManager>();

        _managerList.Add(AtlasManager);
        _managerList.Add(AnimationManager);

        StartCoroutine(BootAllManagers());
    }

    private IEnumerator BootAllManagers()
    {
        foreach (IManager manager in _managerList)
        {
            manager.BootSequence();
        }

        yield return null;
    }
}
