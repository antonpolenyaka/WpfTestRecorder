using WpfTestRecorder.Core;

namespace WpfTestRecorder.Tests;

public class TestActionTests
{
    [Fact]
    public void TestAction_Constructor_ShouldSetTimestamp()
    {
        // Arrange & Act
        var action = new TestAction();

        // Assert
        Assert.True(action.Timestamp > DateTime.MinValue);
        Assert.True(action.Timestamp <= DateTime.Now);
    }

    [Fact]
    public void TestAction_WithActionType_ShouldSetActionType()
    {
        // Arrange & Act
        var action = new TestAction(TestActionType.Click);

        // Assert
        Assert.Equal(TestActionType.Click, action.ActionType);
    }

    [Theory]
    [InlineData(TestActionType.Click, 100, 200, "Click at (100, 200) on unknown")]
    [InlineData(TestActionType.DoubleClick, 50, 75, "Double-click at (50, 75) on unknown")]
    [InlineData(TestActionType.RightClick, 0, 0, "Right-click at (0, 0) on unknown")]
    public void TestAction_ToString_ShouldReturnCorrectFormat(TestActionType actionType, int x, int y, string expected)
    {
        // Arrange
        var action = new TestAction(actionType)
        {
            X = x,
            Y = y
        };

        // Act
        var result = action.ToString();

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestAction_ToString_WithKeyPress_ShouldReturnKeyPressFormat()
    {
        // Arrange
        var action = new TestAction(TestActionType.KeyPress)
        {
            Key = "Enter"
        };

        // Act
        var result = action.ToString();

        // Assert
        Assert.Equal("Key press: Enter", result);
    }

    [Fact]
    public void TestAction_ToString_WithTypeText_ShouldReturnTypeTextFormat()
    {
        // Arrange
        var action = new TestAction(TestActionType.TypeText)
        {
            Text = "Hello World"
        };

        // Act
        var result = action.ToString();

        // Assert
        Assert.Equal("Type text: \"Hello World\"", result);
    }
}