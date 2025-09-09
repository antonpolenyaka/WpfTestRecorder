using System;

namespace WpfTestRecorder.Core;

/// <summary>
/// Represents a test action that can be recorded and played back
/// </summary>
public class TestAction
{
    public TestActionType ActionType { get; set; }
    public string? ElementId { get; set; }
    public string? ElementType { get; set; }
    public int X { get; set; }
    public int Y { get; set; }
    public string? Text { get; set; }
    public string? Key { get; set; }
    public DateTime Timestamp { get; set; }
    public int Delay { get; set; } = 100; // Default delay in milliseconds

    public TestAction()
    {
        Timestamp = DateTime.Now;
    }

    public TestAction(TestActionType actionType) : this()
    {
        ActionType = actionType;
    }

    public override string ToString()
    {
        return ActionType switch
        {
            TestActionType.Click => $"Click at ({X}, {Y}) on {ElementType ?? "unknown"}",
            TestActionType.DoubleClick => $"Double-click at ({X}, {Y}) on {ElementType ?? "unknown"}",
            TestActionType.RightClick => $"Right-click at ({X}, {Y}) on {ElementType ?? "unknown"}",
            TestActionType.KeyPress => $"Key press: {Key}",
            TestActionType.TypeText => $"Type text: \"{Text}\"",
            TestActionType.MouseMove => $"Mouse move to ({X}, {Y})",
            TestActionType.WindowResize => $"Window resize",
            TestActionType.WindowMove => $"Window move",
            TestActionType.Wait => $"Wait {Delay}ms",
            _ => $"Unknown action: {ActionType}"
        };
    }
}