using System.Collections;
using System.Collections.Generic;
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
            StartCoroutine(AnimateText(currentDialogue.dialogueText));
        }
        else
        {
            Dialogue.text = "";
        }
    }

    IEnumerator AnimateText(string dialogueText, float timeBetweenCharacters = 0.05f)
    {
        // TODO: validate if timeBetweenCharacters input        
        Dialogue.text = "";

        foreach (char letter in dialogueText)
        {
            Dialogue.text += letter;
            yield return new WaitForSeconds(timeBetweenCharacters);
        }
    }
}
