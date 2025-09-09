using WpfTestRecorder.Core;

namespace WpfTestRecorder.Tests;

public class TestRecorderTests
{
    [Fact]
    public void TestRecorder_ShouldInitialize_WithEmptyActions()
    {
        // Arrange & Act
        var recorder = new TestRecorder();

        // Assert
        Assert.False(recorder.IsRecording);
        Assert.False(recorder.HasActions);
        Assert.Empty(recorder.GetActions());
    }

    [Fact]
    public void StartRecording_ShouldSetIsRecordingToTrue()
    {
        // Arrange
        var recorder = new TestRecorder();

        // Act
        recorder.StartRecording();

        // Assert
        Assert.True(recorder.IsRecording);
    }

    [Fact]
    public void StopRecording_ShouldSetIsRecordingToFalse()
    {
        // Arrange
        var recorder = new TestRecorder();
        recorder.StartRecording();

        // Act
        recorder.StopRecording();

        // Assert
        Assert.False(recorder.IsRecording);
    }

    [Fact]
    public void RecordAction_WhenRecording_ShouldAddAction()
    {
        // Arrange
        var recorder = new TestRecorder();
        var action = new TestAction(TestActionType.Click) 
        { 
            X = 100, 
            Y = 200 
        };

        // Act
        recorder.StartRecording();
        recorder.RecordAction(action);

        // Assert
        Assert.True(recorder.HasActions);
        Assert.Single(recorder.GetActions());
    }

    [Fact]
    public void RecordAction_WhenNotRecording_ShouldNotAddAction()
    {
        // Arrange
        var recorder = new TestRecorder();
        var action = new TestAction(TestActionType.Click) 
        { 
            X = 100, 
            Y = 200 
        };

        // Act
        recorder.RecordAction(action);

        // Assert
        Assert.False(recorder.HasActions);
        Assert.Empty(recorder.GetActions());
    }
}