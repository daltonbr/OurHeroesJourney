using System.Collections.Generic;

public class NarrativeEvent
{
    public List<Dialogue> dialogues;
}

public struct Dialogue
{
    public CharacterType characterType;
    public string name;
    public string atlasImageName;
    public string dialogueText;
}

public enum CharacterType
{
    Hero, Ally, Mentor
}
