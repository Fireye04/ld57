using Godot;
using System;
using DialogueManagerRuntime;

public partial class Main : Control {
    [Export]
    public Resource dialogue;
    public override void _Ready() {
        DialogueManager.ShowDialogueBalloon(dialogue, "start");
    }
}
