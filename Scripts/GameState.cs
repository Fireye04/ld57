using Godot;
using System;
using System.Runtime.Serialization;

public partial class GameState : Node {

    // Signal declaration
    [Signal]
    public delegate void ConfidenceChangeEventHandler(int trust);

    [Signal]
    public delegate void EmotionChangeEventHandler(int emotion);

    [Signal]
    public delegate void DoorIsOpenEventHandler(bool status);

    [Signal]
    public delegate void TalkingStatusEventHandler(bool isTalking);

    [Signal]
    public delegate void FadeOutEventHandler();

    [Signal]
    public delegate void FadeInEventHandler();

    // Singleton Handler
    private static GameState instance;

    public static GameState GetGSInstance() { return instance; }

    private void SetGSInstance(GameState newGSInstance) {
        instance = newGSInstance;
    }

    // Signal triggers
    public void toBlack() { EmitSignal(SignalName.FadeOut); }
    public void fromBlack() { EmitSignal(SignalName.FadeIn); }
    public void doorClose() { EmitSignal(SignalName.DoorIsOpen, false); }
    public void doorOpen() { EmitSignal(SignalName.DoorIsOpen, true); }

    // Variable declarations
    private int Confidence;

    public int confidence {
        get { return Confidence; }
        set {
            EmitSignal(SignalName.ConfidenceChange, value);
            Confidence = value;
        }
    }

    private EEmotion Emotion;

    public EEmotion emotion {
        get { return Emotion; }
        set {
            EmitSignal(SignalName.EmotionChange, (int)value);
            Emotion = value;
        }
    }

    private bool Talking;

    public bool talking {
        get { return Talking; }
        set {
            EmitSignal(SignalName.TalkingStatus, value);
            Talking = value;
        }
    }

    public AudioStreamPlayer playr;

    public int bathroomCount;

    public int nikeRep;

    public override void _Ready() {
        SetGSInstance(this);
        playr = GetNode<AudioStreamPlayer>("AudioPlayer");
        resetValues();
    }

    public void resetValues() {
        confidence = 4;
        bathroomCount = 0;
        nikeRep = 0;
        emotion = EEmotion.HAPPY;
        talking = false;
        bathroomCount = 0;
        nikeRep = 0;
        music("main");
    }

    public void changeScene(PackedScene scene) {
        GetTree().ChangeSceneToPacked(scene);
    }

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

    public void playAgain() {
        resetValues();
        changeScene(ResourceLoader.Load<PackedScene>("res://Scenes/main.tscn"));
    }
}
