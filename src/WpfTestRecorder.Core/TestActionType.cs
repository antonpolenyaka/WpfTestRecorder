namespace WpfTestRecorder.Core;

/// <summary>
/// Enumeration of supported test action types
/// </summary>
public enum TestActionType
{
    /// <summary>
    /// Left mouse click
    /// </summary>
    Click,
    
    /// <summary>
    /// Double left mouse click
    /// </summary>
    DoubleClick,
    
    /// <summary>
    /// Right mouse click
    /// </summary>
    RightClick,
    
    /// <summary>
    /// Single key press
    /// </summary>
    KeyPress,
    
    /// <summary>
    /// Text typing
    /// </summary>
    TypeText,
    
    /// <summary>
    /// Mouse movement
    /// </summary>
    MouseMove,
    
    /// <summary>
    /// Window resize action
    /// </summary>
    WindowResize,
    
    /// <summary>
    /// Window move action
    /// </summary>
    WindowMove,
    
    /// <summary>
    /// Wait/delay action
    /// </summary>
    Wait
}