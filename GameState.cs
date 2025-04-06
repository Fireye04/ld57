using Godot;
using System;
using System.Runtime.Serialization;

public partial class GameState : Node {

    private static GameState instance;

    public static GameState GetGSInstance() { return instance; }

    private void SetGSInstance(GameState newGSInstance) {
        instance = newGSInstance;
    }

    public override void _Ready() { SetGSInstance(this); }

    [Signal]
    public delegate void ConfidenceChangeEventHandler(int trust);

    private int Confidence = 10;

    public int confidence {
        get { return Confidence; }
        set {
            EmitSignal(SignalName.ConfidenceChange, value);
            Confidence = value;
        }
    }

    public int bathroomCount = 0;
}
