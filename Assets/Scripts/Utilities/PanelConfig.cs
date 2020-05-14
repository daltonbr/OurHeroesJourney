using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PanelConfig : MonoBehaviour
{
    public bool CharacterIsTalking;
    public Image AvatarImage;
    public Image TextBackground;
    public Text CharacterName;
    public Text Dialogue;

    [SerializeField]
    private Color _maskActiveColor = new Color(103.0f/255.0f, 101.0f/255.0f, 101.0f / 255.0f);

    public void ToggleCharacterMask()
    {
        if (CharacterIsTalking)
        {
            AvatarImage.color = Color.white;
            TextBackground.color = Color.white;
        }
        else
        {
            AvatarImage.color = _maskActiveColor;
            TextBackground.color = _maskActiveColor;
        }
    }

    public void Configure(Dialogue currentDialogue)
    {
        ToggleCharacterMask();

        AvatarImage.sprite = MasterManager.AtlasManager.LoadSprite(currentDialogue.atlasImageName);
        CharacterName.text = currentDialogue.name;
        
        if (CharacterIsTalking)
        {
            StartCoroutine(AnimateText(currentDialogue.dialogueText, 0.03f));
        }
        else
        {
            Dialogue.text = string.Empty;
        }
    }

    private IEnumerator AnimateText(string dialogueText, float timeBetweenCharacters = 0.05f)
    {
        Dialogue.text = string.Empty;
        StringBuilder builder = new StringBuilder(string.Empty, dialogueText.Length);
        WaitForSeconds wait = new WaitForSeconds(timeBetweenCharacters);
        
        foreach (char letter in dialogueText)
        {
            builder.Append(letter);
            Dialogue.text = builder.ToString();
            yield return wait;
        }
    }
}
