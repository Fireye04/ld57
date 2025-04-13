using Godot;
using System;

public partial class Fader : Control {
    public AnimationPlayer anim;

    public override void _Ready() {

        GameState.GetGSInstance().Connect(GameState.SignalName.FadeOut,
                                          Callable.From(fadeOut));
        GameState.GetGSInstance().Connect(GameState.SignalName.FadeIn,
                                          Callable.From(fadeIn));

        anim = GetNode<AnimationPlayer>("%Anim");
        anim.Play("from_black");
    }

    public void fadeOut() { anim.Play("to_black"); }
    public void fadeIn() { anim.Play("from_black"); }
}
