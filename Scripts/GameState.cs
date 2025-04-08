using Godot;
using System;
using System.Runtime.Serialization;

public partial class GameState : Node {

    private static GameState instance;

    public static GameState GetGSInstance() { return instance; }

    private void SetGSInstance(GameState newGSInstance) {
        instance = newGSInstance;
    }
    public AudioStreamPlayer2D playr;

    public override void _Ready() {
        SetGSInstance(this);
        playr = GetNode<AudioStreamPlayer2D>("AudioPlayer");
        music("main");
    }

    [Signal]
    public delegate void ConfidenceChangeEventHandler(int trust);

    [Signal]
    public delegate void EmotionChangeEventHandler(int emotion);

    [Signal]
    public delegate void CloseDoorEventHandler();

    [Signal]
    public delegate void TalkingStatusEventHandler(bool isTalking);

    [Signal]
    public delegate void FadeOutEventHandler();

    [Signal]
    public delegate void FadeInEventHandler();

    [Signal]
    public delegate void EndEventHandler();

    public void toBlack() { EmitSignal(SignalName.FadeOut); }
    public void fromBlack() { EmitSignal(SignalName.FadeIn); }

    public void doorClose() { EmitSignal(SignalName.CloseDoor); }
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

    public void toggleEnd() { EmitSignal(SignalName.End); }

    public void music(String track) {
        switch (track) {
        case "main": {
            playr.Stream = (AudioStreamMP3)ResourceLoader.Load(
                "res://Assets/Audio/OST/main_theme.mp3");
            playr.Play();
            break;
        }
        case "ominous": {
            playr.Stream = (AudioStreamMP3)ResourceLoader.Load(
                "res://Assets/Audio/OST/Ommy Nous.mp3");
            playr.Play();
            break;
        }
        case "fast": {
            playr.Stream = (AudioStreamMP3)ResourceLoader.Load(
                "res://Assets/Audio/OST/Escalation.mp3");
            playr.Play();
            break;
        }
        case "emotional": {
            playr.Stream = (AudioStreamMP3)ResourceLoader.Load(
                "res://Assets/Audio/OST/Sentimentality.mp3");
            playr.Play();
            break;
        }
        }
    }
}
