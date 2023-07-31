using System;
using System.Windows.Input;

namespace Ametrin.Utils.WPF;

public sealed class RelayCommand : ICommand{
    private readonly Action<object?> Command;
    private readonly Func<object?, bool>? CanRun;

    public event EventHandler? CanExecuteChanged {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public RelayCommand(Action<object?> command, Func<object?, bool>? canRun = null){
        Command = command;
        CanRun = canRun;
    }

    public bool CanExecute(object? parameter = null) => CanRun is null || CanRun(parameter);

    public void Execute(object? parameter = null) => Command(parameter);
}