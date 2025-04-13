using Godot;
using System;
using DialogueManagerRuntime;

public partial class Main : Control {
    [Export]
    public Resource dialogue;

    [Export]
    public PackedScene nextScene;

    public override void _Ready() {
        DialogueManager.ShowDialogueBalloon(dialogue, "start");
        DialogueManager.DialogueEnded += (Resource dialogueResource) => {
            GameState.GetGSInstance().changeScene(nextScene);
        };
    }
}
