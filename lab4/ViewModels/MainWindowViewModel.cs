using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using lab4.Models;

namespace lab4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string text;
        RomanNumberExtend? num1;
        RomanNumberExtend? num2;
        bool isTwoArgs = false;
        string Op { get; set; }
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                this.RaiseAndSetIfChanged(ref text, value);
            }
        }
        public MainWindowViewModel()
        {
            OnClickCommand = ReactiveCommand.Create<string, string>((str) => Text += str);
            OperationCommand = ReactiveCommand.Create<string>((op) => DoOperation(op));
        }
        public ReactiveCommand<string,string> OnClickCommand { get; }
        public ReactiveCommand<string, Unit> OperationCommand { get; }
        public void DoOperation(string op)
        {
            if (!isTwoArgs)
            {
                if (op == "=") Text = "";
                SaveNum(ref num1);
                isTwoArgs = true;
                if (op != "=") Op = op;
            }
            else
            {
                SaveNum(ref num2);
                isTwoArgs = false;
                if (Op == "+") Text = (num1 + num2).ToString();
                else if (Op == "-") Text = (num1 - num2).ToString();
                else if (Op == "*") Text = (num1 * num2).ToString();
                else if (Op == "/") Text = (num1 / num2).ToString();
            }
        }
        private void SaveNum(ref RomanNumberExtend num)
        {
            num = new(Text);
            Text = "";
        }
    }
}
