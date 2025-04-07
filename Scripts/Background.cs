using Godot;
using System;

public partial class Background : AnimationPlayer {

    public override void _Ready() {

        GameState.GetGSInstance().TalkingStatus += (val) => setTalking(val);
        GameState.GetGSInstance().EmotionChange += (val) => setEmotion(val);
    }

    public String speaking = "idle";

    public String emotion = "happy";

    public void setTalking(bool val) {
        if (val) {
            speaking = "talk";
        } else {
            speaking = "idle";
        }
        Play(speaking + "_" + emotion + "_nike");
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
        Play(speaking + "_" + emotion + "_nike");
    }
}
