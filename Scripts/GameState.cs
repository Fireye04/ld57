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

    // need to expose function for some reason
    public void setConfidence(int value) { confidence = value; }

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

    private Godot.Collections.Array<String> eventList;

    // Adds eventName to eventList
    public void next(String eventName) {
        eventList.Add(eventName);
        GD.Print(eventList);
    }

    // Checks if eventName occurred
    public void evContains(String eventName) { eventList.Add(eventName); }

    // Checks if all of the events in eventNames occurred
    public bool evContains(params String[] eventNames) {
        for (int i = 0; i < eventNames.Length; i++) {
            if (!eventList.Contains(eventNames[i])) {
                return false;
            }
        }
        return true;
    }
    // Checks if all of the events in eventNames occurred in order
    public bool evContainsOrdered(params String[] eventNames) {
        int eventCount = 0;
        for (int i = 0; i < eventList.Count; i++) {

            if (eventList[i] == eventNames[eventCount]) {
                eventCount++;
                if (eventCount >= eventNames.Length) {
                    return true;
                }
            }
        }
        return false;
    }

    public int NikeRep;

    public int nikeRep {
        get { return NikeRep; }
        set {
            GD.Print(NikeRep);
            NikeRep = value;
        }
    }

    public override void _Ready() {
        SetGSInstance(this);
        playr = GetNode<AudioStreamPlayer>("AudioPlayer");
        resetValues();
    }

    public void resetValues() {
        confidence = 4;
        nikeRep = 0;
        emotion = EEmotion.HAPPY;
        talking = false;
        nikeRep = 0;
        eventList = new Godot.Collections.Array<String>();
        if (playr.Stream != (AudioStreamMP3)ResourceLoader.Load(
                                "res://Assets/Audio/OST/main_theme.mp3")) {
            music("main");
        }
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
