using UnityEngine;
using JSONFactory;

public class PanelManager : MonoBehaviour, IManager
{
    public ManagerState CurrentState { get; private set; }

    private PanelConfig _rightPanel;
    private PanelConfig _leftPanel;

    private NarrativeEvent _currentEvent;
    private bool _leftCharacterActive = true;
    private int _stepIndex = 0;

    public void BootSequence()
    {
        Debug.Log($"{GetType().Name} is booting up");

        // TODO: make a better way to get these references
        _rightPanel = GameObject.Find("RightCharacterPanel").GetComponent<PanelConfig>();
        _leftPanel = GameObject.Find("LeftCharacterPanel").GetComponent<PanelConfig>();
        _currentEvent = JSONAssembly.RunJSONFactoryForScene(1);
        InitializePanels();

        Debug.Log($"{GetType().Name} status = {CurrentState}");
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

        _leftPanel.Configure(_currentEvent.dialogues[_stepIndex]);
        _rightPanel.Configure(_currentEvent.dialogues[_stepIndex + 1]);

        StartCoroutine(MasterManager.AnimationManager.IntroAnimation());

        _stepIndex++;
    }

    private void ConfigurePanels()
    {
        if (_leftCharacterActive)
        {
            _leftPanel.CharacterIsTalking = true;
            _rightPanel.CharacterIsTalking = false;

            _leftPanel.Configure(_currentEvent.dialogues[_stepIndex]);
            _rightPanel.ToggleCharacterMask();
        }
        else
        {
            _leftPanel.CharacterIsTalking = false;
            _rightPanel.CharacterIsTalking = true;

            _leftPanel.ToggleCharacterMask();
            _rightPanel.Configure(_currentEvent.dialogues[_stepIndex]);
        }
    }
    private void UpdatePanelState()
    {
        if (_stepIndex < _currentEvent.dialogues.Count)
        {
            ConfigurePanels();

            _leftCharacterActive = !_leftCharacterActive;
            _stepIndex++;
        }
        else
        {
            StartCoroutine(MasterManager.AnimationManager.ExitAnimation());
        }
    }

}
