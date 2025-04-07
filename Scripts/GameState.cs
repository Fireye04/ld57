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

    [Signal]
    public delegate void EmotionChangeEventHandler(int emotion);

    [Signal]
    public delegate void TalkingStatusEventHandler(bool isTalking);

    private int Confidence = 10;

    public int confidence {
        get { return Confidence; }
        set {
            EmitSignal(SignalName.ConfidenceChange, value);
            Confidence = value;
        }
    }

    private EEmotion Emotion = EEmotion.HAPPY;

    public EEmotion emotion {
        get { return Emotion; }
        set {
            EmitSignal(SignalName.EmotionChange, (int)value);
            Emotion = value;
        }
    }

    private bool Talking = false;

    public bool talking {
        get { return Talking; }
        set {
            EmitSignal(SignalName.TalkingStatus, value);
            Talking = value;
        }
    }
    public int bathroomCount = 0;

    public int nikeRep = 0;
}
