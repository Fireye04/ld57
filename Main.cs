using Godot;
using System;
using DialogueManagerRuntime;

public partial class Main : Node3D
{
    [Export]
    public Resource dialogue;
    public override void _Ready()
    {
        DialogueManager.ShowDialogueBalloon(dialogue, "start");
    }

}
