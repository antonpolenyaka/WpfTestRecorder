using System;
using WpfTestRecorder.Core;

namespace WpfTestRecorder.App;

class Program
{
    private static TestRecorder? _testRecorder;
    private static bool _running = true;

    static void Main(string[] args)
    {
        Console.WriteLine("=== WPF Test Recorder ===");
        Console.WriteLine("A .NET 8.0 solution for recording and replaying UI tests");
        Console.WriteLine();

        _testRecorder = new TestRecorder();

        ShowHelp();
        
        while (_running)
        {
            Console.Write("\nWPF Test Recorder> ");
            var input = Console.ReadLine()?.Trim().ToLower();
            
            ProcessCommand(input);
        }
    }

    private static void ProcessCommand(string? command)
    {
        switch (command)
        {
            case "record" or "r":
                StartRecording();
                break;
            case "stop" or "s":
                StopRecording();
                break;
            case "demo" or "d":
                RunDemo();
                break;
            case "list" or "l":
                ListActions();
                break;
            case "clear" or "c":
                ClearActions();
                break;
            case "save":
                SaveTest();
                break;
            case "load":
                LoadTest();
                break;
            case "help" or "h" or "?":
                ShowHelp();
                break;
            case "exit" or "quit" or "q":
                _running = false;
                Console.WriteLine("Goodbye!");
                break;
            default:
                Console.WriteLine("Unknown command. Type 'help' for available commands.");
                break;
        }
    }

    private static void StartRecording()
    {
        if (_testRecorder!.IsRecording)
        {
            Console.WriteLine("Already recording!");
            return;
        }

        _testRecorder.StartRecording();
        Console.WriteLine("Recording started. Type 'stop' to stop recording.");
        Console.WriteLine("(Note: This is a demo - actual UI recording would require platform-specific hooks)");
    }

    private static void StopRecording()
    {
        if (!_testRecorder!.IsRecording)
        {
            Console.WriteLine("Not currently recording.");
            return;
        }

        _testRecorder.StopRecording();
        Console.WriteLine("Recording stopped.");
    }

    private static void RunDemo()
    {
        Console.WriteLine("Running demo test recording...");
        
        _testRecorder!.StartRecording();
        
        // Simulate some test actions
        _testRecorder.RecordAction(new TestAction(TestActionType.Click) 
        { 
            X = 100, 
            Y = 200, 
            ElementType = "Button",
            ElementId = "StartButton"
        });
        
        _testRecorder.RecordAction(new TestAction(TestActionType.TypeText) 
        { 
            Text = "Hello, World!",
            ElementType = "TextBox",
            ElementId = "InputField"
        });
        
        _testRecorder.RecordAction(new TestAction(TestActionType.KeyPress) 
        { 
            Key = "Enter"
        });
        
        _testRecorder.RecordAction(new TestAction(TestActionType.DoubleClick) 
        { 
            X = 300, 
            Y = 150,
            ElementType = "ListItem",
            ElementId = "ResultItem"
        });

        _testRecorder.StopRecording();
        
        Console.WriteLine("Demo recording completed!");
        Console.WriteLine($"Recorded {_testRecorder.GetActions().Count()} actions.");
    }

    private static void ListActions()
    {
        var actions = _testRecorder!.GetActions().ToList();
        
        if (!actions.Any())
        {
            Console.WriteLine("No actions recorded.");
            return;
        }

        Console.WriteLine($"\nRecorded Actions ({actions.Count}):");
        Console.WriteLine(new string('-', 50));
        
        for (int i = 0; i < actions.Count; i++)
        {
            Console.WriteLine($"{i + 1,3}. {actions[i]}");
        }
    }

    private static void ClearActions()
    {
        _testRecorder!.StartRecording();
        _testRecorder.StopRecording();
        Console.WriteLine("All actions cleared.");
    }

    private static void SaveTest()
    {
        if (!_testRecorder!.HasActions)
        {
            Console.WriteLine("No actions to save.");
            return;
        }

        Console.Write("Enter filename (without extension): ");
        var filename = Console.ReadLine()?.Trim();
        
        if (string.IsNullOrEmpty(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }

        try
        {
            var fullPath = $"{filename}.json";
            _testRecorder.SaveTest(fullPath);
            Console.WriteLine($"Test saved to: {fullPath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving test: {ex.Message}");
        }
    }

    private static void LoadTest()
    {
        Console.Write("Enter filename (with or without .json extension): ");
        var filename = Console.ReadLine()?.Trim();
        
        if (string.IsNullOrEmpty(filename))
        {
            Console.WriteLine("Invalid filename.");
            return;
        }

        if (!filename.EndsWith(".json"))
            filename += ".json";

        try
        {
            _testRecorder!.LoadTest(filename);
            Console.WriteLine($"Test loaded from: {filename}");
            Console.WriteLine($"Loaded {_testRecorder.GetActions().Count()} actions.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading test: {ex.Message}");
        }
    }

    private static void ShowHelp()
    {
        Console.WriteLine("Available Commands:");
        Console.WriteLine("  record, r    - Start recording test actions");
        Console.WriteLine("  stop, s      - Stop recording");
        Console.WriteLine("  demo, d      - Run a demo recording");
        Console.WriteLine("  list, l      - List recorded actions");
        Console.WriteLine("  clear, c     - Clear all recorded actions");
        Console.WriteLine("  save         - Save test to file");
        Console.WriteLine("  load         - Load test from file");
        Console.WriteLine("  help, h, ?   - Show this help");
        Console.WriteLine("  exit, q      - Exit application");
    }
}
