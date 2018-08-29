using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AtlasManager))]
public class MasterManager : MonoBehaviour
{
    private List<IManager> _managerList = new List<IManager>();

    public static AtlasManager AtlasManager { get; private set; }

    private void Awake()
    {
        AtlasManager = GetComponent<AtlasManager>();
        _managerList.Add(AtlasManager);

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
