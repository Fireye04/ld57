using Godot;
using System;

public partial class ToBeContinued : Control {
    [Export]
    public PackedScene menu;

    public void _on_playagain_pressed() {
        GameState.GetGSInstance().playAgain();
    }
    public void _on_menu_pressed() {
        GameState.GetGSInstance().changeScene(menu);
    }
}
