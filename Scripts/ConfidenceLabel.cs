using Godot;
using System;

public partial class ConfidenceLabel : Label {
    public override void _EnterTree() {
        GameState.GetGSInstance().Connect(GameState.SignalName.ConfidenceChange,
                                          Callable.From<int>(setValue));
    }

    public void setValue(int val) {
        GetNode<Label>("%Confidence").Text = "Confidence: " + val;
    }
}
