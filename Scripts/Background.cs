using Godot;
using System;

public partial class Background : Control {

    public AnimationPlayer anim;

    public override void _Ready() {

        GameState.GetGSInstance().TalkingStatus += (val) => setTalking(val);
        GameState.GetGSInstance().EmotionChange += (val) => setEmotion(val);
        anim = GetNode<AnimationPlayer>("%Anim");
    }

    public String speaking = "idle";

    public String emotion = "happy";

    public void setTalking(bool val) {
        if (val) {
            speaking = "talk";
        } else {
            speaking = "idle";
        }
        anim.Play(speaking + "_" + emotion + "_nike");
    }
    public void setEmotion(int val) {
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
