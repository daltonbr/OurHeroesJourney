using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JSONFactory;

public class PanelManager : MonoBehaviour, IManager
{
    public ManagerState CurrentState { get; private set; }

    private PanelConfig _rightPanel;
    private PanelConfig _leftPanel;

    private NarrativeEvent _currentEvent;
    private bool _leftCharacterActive = true;
    private int stepIndex = 0;

    public void BootSequence()
    {
        Debug.Log(string.Format("{0} is booting up", GetType().Name));

        // TODO: make a better way to get these references
        _rightPanel = GameObject.Find("RightCharacterPanel").GetComponent<PanelConfig>();
        _leftPanel = GameObject.Find("LeftCharacterPanel").GetComponent<PanelConfig>();
        _currentEvent = JSONAssembly.RunJSONFactoryForScene(1);
        InitializePanels();

        Debug.Log(string.Format("{0} status = {1}", GetType().Name, CurrentState));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdatePanelState();
        }
    }


    private void InitializePanels()
    {
        _leftPanel.CharacterIsTalking = true;
        _rightPanel.CharacterIsTalking = false;
        _leftCharacterActive = !_leftCharacterActive;

        _leftPanel.Configure(_currentEvent.dialogues[stepIndex]);
        _rightPanel.Configure(_currentEvent.dialogues[stepIndex + 1]);

        StartCoroutine(MasterManager.AnimationManager.IntroAnimation());

        stepIndex++;
    }

    private void ConfigurePanels()
    {
        if (_leftCharacterActive)
        {
            _leftPanel.CharacterIsTalking = true;
            _rightPanel.CharacterIsTalking = false;

            _leftPanel.Configure(_currentEvent.dialogues[stepIndex]);
            _rightPanel.ToggleCharacterMask();
        }
        else
        {
            _leftPanel.CharacterIsTalking = false;
            _rightPanel.CharacterIsTalking = true;

            _leftPanel.ToggleCharacterMask();
            _rightPanel.Configure(_currentEvent.dialogues[stepIndex]);
        }
    }
    private void UpdatePanelState()
    {
        if (stepIndex < _currentEvent.dialogues.Count)
        {
            ConfigurePanels();

            _leftCharacterActive = !_leftCharacterActive;
            stepIndex++;
        }
        else
        {
            StartCoroutine(MasterManager.AnimationManager.ExitAnimation());
        }
    }

}
