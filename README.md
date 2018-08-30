# Build a Character Dialogue System in Unity with JSON

by Harrison Ferrone

[www.linkedin.com/learning/unity-5-build-a-character-dialogue-system/](https://www.linkedin.com/learning/unity-5-build-a-character-dialogue-system/)

## Summary

Game programmers and designers are often left to fend for themselves when learning how to write, structure, and manage efficient event systems of their own making. This course has two goals: (1) to convey how fundamental programming patterns and industry standards apply to game development and (2) to equip developers with the theoretical tools needed to inject their projects with engaging narratives, resulting in emotional player investment that comes with story-driven gameplay. This course also covers story-driven game design theory, creating the building blocks of an interactive system, abstracting building blocks into a scalable management class, and more.

![Dialogue](Dialogue.PNG)

See my [Course Notes](BuildACharacterDialogueSystem.md) to see more in-depth information.

## Tools

[litjson.net](https://litjson.net/)
[TexturePacker](https://www.codeandweb.com/texturepacker)
[Unity 2018.2.5f1](https://unity3d.com/)

## A Dialogue in JSON

```JSON
{
  "dialogues":
  [
        {
          "characterType": 0,
          "name": "Hero",
          "atlasImageName": "Hero_Default",
          "dialogueText": "Time to address the Call to Adventure."
        },
        {
          "characterType": 1,
          "name": "Ally",
          "atlasImageName": "Heroine_Surprised",
          "dialogueText": "Are you sure? I might need some coffee first."
        }
  ]
}
```