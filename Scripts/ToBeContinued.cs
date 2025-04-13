using Godot;
using System;

public partial class ToBeContinued : Control {
    [Export]
    private PackedScene nextScene;

    public void _on_playagain_pressed() {
        GameState.GetGSInstance().playAgain();
    }
    public void _on_menu_pressed() {
        GameState.GetGSInstance().changeScene(nextScene);
    }
}
