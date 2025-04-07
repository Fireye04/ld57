using Godot;
using System;

public partial class ConfidenceLabel : Label {
    public override void _Ready() {

        GameState.GetGSInstance().ConfidenceChange += (val) => setValue(val);
    }

    public void setValue(int val) {
        GetNode<Label>("%Confidence").Text = "Confidence: " + val;
    }
}
