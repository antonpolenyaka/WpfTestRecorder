using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace WpfTestRecorder.Core;

/// <summary>
/// Main class for recording and playing back UI test actions
/// </summary>
public class TestRecorder
{
    private readonly List<TestAction> _actions = new();
    private bool _isRecording = false;

    public bool IsRecording => _isRecording;
    public bool HasActions => _actions.Count > 0;

    public void StartRecording()
    {
        _isRecording = true;
        _actions.Clear();
        
        // TODO: Set up low-level hooks for mouse and keyboard events
        // For now, this is a placeholder implementation
    }

    public void StopRecording()
    {
        _isRecording = false;
        
        // TODO: Remove low-level hooks
    }

    public void RecordAction(TestAction action)
    {
        if (_isRecording)
        {
            _actions.Add(action);
        }
    }

    public IEnumerable<TestAction> GetActions()
    {
        return _actions.AsReadOnly();
    }

    public void LoadTest(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"Test file not found: {filePath}");

        var json = File.ReadAllText(filePath);
        var actions = JsonSerializer.Deserialize<List<TestAction>>(json);
        
        _actions.Clear();
        if (actions != null)
        {
            _actions.AddRange(actions);
        }
    }

    public void SaveTest(string filePath)
    {
        var json = JsonSerializer.Serialize(_actions, new JsonSerializerOptions 
        { 
            WriteIndented = true 
        });
        
        File.WriteAllText(filePath, json);
    }

    public void PlayTest()
    {
        // TODO: Implement playback logic
        foreach (var action in _actions)
        {
            // Simulate action execution
            System.Threading.Thread.Sleep(action.Delay);
        }
    }
}
