# Build a Character Dialogue System

by Harrison Ferrone

[www.linkedin.com/learning/unity-5-build-a-character-dialogue-system/](https://www.linkedin.com/learning/unity-5-build-a-character-dialogue-system/)

## Summary

Game programmers and designers are often left to fend for themselves when learning how to write, structure, and manage efficient event systems of their own making. This course has two goals: (1) to convey how fundamental programming patterns and industry standards apply to game development and (2) to equip developers with the theoretical tools needed to inject their projects with engaging narratives, resulting in emotional player investment that comes with story-driven gameplay. This course also covers story-driven game design theory, creating the building blocks of an interactive system, abstracting building blocks into a scalable management class, and more.

## Narrative Game Design Primer

### Keep empathy in mind

* Important to understand how players identify with your characters
* Leads to higher and longer engagements with the game

### Memory Lane

* Why there are such strong emotional connections to your favorite games?
* Great narrative design is responsible for those connections

### The End Game

* Consider how your narrative impacts the connections between your players and your game
* Make your players feel for your characters and story
* Pay special attention to your protagonist
* Aim to have your players feel they are your heroic character

## Fostering Engagement

### Applying Empathy

* Was it the mechanics?
* The graphics?
* The online community?
* Maybe even the new console you were playing it on?

### For your consideration

* Does this character of interaction serve a specific purpose, or is it just filler?
* Have I create an interaction that can be built on later?
* Have I considered how a character I've brought into the narrative will engage my players?
* Will the characters I create be able to engage different audiences of players? If not, will that exclusion disrupt potential engagement? How can I address that?

### Emotional Investment

* Infinite loops
  * empathetic connections -> higher engagement -> deeper emotional investment

### Everyone has a story

* Narratives come in many forms, some of them unconventional
* Multiplayer/online games often create narratives using their player communities
* Concepts of empathy, engagement, and emotional investment apply

### Shoot for Content

* Design your narratives to create a sense of emotional satisfaction
* Don't settle for creating easy connections
* "Emotional content, not anger", Bruce Lee

## Import Assets from External Resources

### Use interfaces

* Passing down properties and methods leads to complex inheritance trees
* Interfaces allow classes to subscribe to multiple shared properties and methods

Using interfaces can help us reduce the clutter caused by inheritances.

### Write the JSON file

Our JSON structure will be

NarrativeEvent
Dialogues - list of Dialogue objects
Dialogue object - character type, image, text

#### Example of a Dialogue

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

It's always a good idea to validate our JSON files.

[jsonformatter.curiousconcept.com/](https://jsonformatter.curiousconcept.com/)

## Quiz

Interfaces are a useful to:

* simplifying inheritance trees and class hierarchies
* writing clearer code
* abstracting out common properties and behaviors

Q: What should all good game architecture have?
A: An overall access point for important systems