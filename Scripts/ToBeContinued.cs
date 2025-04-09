using Godot;
using System;

public partial class ToBeContinued : Control {
    public override void _Ready() {

        GameState.GetGSInstance().End += () => show();
    }

    public void show() { Visible = true; }

    public void _on_button_pressed() { GetTree().Quit(); }
}
