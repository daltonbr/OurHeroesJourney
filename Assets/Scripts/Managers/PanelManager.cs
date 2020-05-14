using UnityEngine;
using JSONFactory;
#if UNITY_EDITOR
using UnityEngine.Assertions;
#endif

public class PanelManager : MonoBehaviour, IManager
{
    public ManagerState CurrentState { get; private set; }
    private const int SceneBuildIndex = 0;
    [Header("Panels")]
    [SerializeField] private PanelConfig rightPanel;
    [SerializeField] private PanelConfig leftPanel;

    private NarrativeEvent _currentEvent;
    private bool _leftCharacterActive = true;
    private int _stepIndex = 0;

    private void Awake()
    {
#if UNITY_EDITOR
        Assert.IsNotNull(rightPanel);
        Assert.IsNotNull(leftPanel);
#endif
    }

    public void BootSequence()
    {
        Debug.Log($"{GetType().Name} is booting up");
        _currentEvent = JSONAssembly.RunJSONFactoryForScene(SceneBuildIndex);
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
        StartCoroutine(MasterManager.AnimationManager.IntroAnimation());
        
        leftPanel.CharacterIsTalking = true;
        rightPanel.CharacterIsTalking = false;
        _leftCharacterActive = !_leftCharacterActive;

        leftPanel.Configure(_currentEvent.dialogues[_stepIndex]);
        rightPanel.Configure(_currentEvent.dialogues[_stepIndex + 1]);
        
        _stepIndex++;
    }

    private void ConfigurePanels()
    {
        if (_leftCharacterActive)
        {
            leftPanel.CharacterIsTalking = true;
            rightPanel.CharacterIsTalking = false;

            leftPanel.Configure(_currentEvent.dialogues[_stepIndex]);
            rightPanel.ToggleCharacterMask();
        }
        else
        {
            leftPanel.CharacterIsTalking = false;
            rightPanel.CharacterIsTalking = true;

            leftPanel.ToggleCharacterMask();
            rightPanel.Configure(_currentEvent.dialogues[_stepIndex]);
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
