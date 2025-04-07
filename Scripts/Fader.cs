using Godot;
using System;

public partial class Fader : Control {
    public AnimationPlayer anim;

    public override void _Ready() {

        GameState.GetGSInstance().FadeOut += () => fadeOut();
        GameState.GetGSInstance().FadeIn += () => fadeIn();
        anim = GetNode<AnimationPlayer>("%Anim");
        anim.Play("from_black");
    }

    public void fadeOut() { anim.Play("to_black"); }
    public void fadeIn() { anim.Play("from_black"); }
}
