using Godot;
using System;

public partial class Background : Control {

    public AnimationPlayer anim;

    public bool closed;
    public override void _Ready() {

        GameState.GetGSInstance().TalkingStatus += (val) => setTalking(val);
        GameState.GetGSInstance().EmotionChange += (val) => setEmotion(val);
        GameState.GetGSInstance().CloseDoor += () => doorClose();
        anim = GetNode<AnimationPlayer>("%Anim");
        closed = false;
    }

    public void doorClose() {
        anim.Play("door_closed");
        closed = true;
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
