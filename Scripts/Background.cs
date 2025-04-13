using Godot;
using System;

public partial class Background : Control {

    public AnimationPlayer anim;

    public bool closed;
    public override void _Ready() {

        GameState.GetGSInstance().Connect(GameState.SignalName.TalkingStatus,
                                          Callable.From<bool>(setTalking));
        GameState.GetGSInstance().Connect(GameState.SignalName.EmotionChange,
                                          Callable.From<int>(setEmotion));
        GameState.GetGSInstance().Connect(GameState.SignalName.DoorIsOpen,
                                          Callable.From<bool>(toggleDoor));
        anim = GetNode<AnimationPlayer>("%Anim");
        closed = true;
    }

    public void toggleDoor(bool makeOpen) {
        if (makeOpen) {
            anim.Play("door_opened");
            closed = false;
        } else {
            anim.Play("door_closed");
            closed = true;
        }
    }

    public String speaking = "idle";

    public String emotion = "happy";

    public void setTalking(bool val) {
        if (closed) {
            return;
        }
        if (val) {
            speaking = "talk";
        } else {
            speaking = "idle";
        }
        anim.Play(speaking + "_" + emotion + "_nike");
    }
    public void setEmotion(int val) {
        if (closed) {
            return;
        }
        switch (val) {
        case 0: {
            emotion = "happy";
            break;
        }
        case 1: {
            emotion = "angry";
            break;
        }
        case 2: {
            emotion = "concerned";
            break;
        }
        default: {
            break;
        }
        }
        anim.Play(speaking + "_" + emotion + "_nike");
    }
}
