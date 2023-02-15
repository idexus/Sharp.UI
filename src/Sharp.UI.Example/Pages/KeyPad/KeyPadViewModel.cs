using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ExampleApp
{
    public class KeypadViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddCharCommand { get; private set; }
        public ICommand DeleteCharCommand { get; private set; }

        private string displayText = "";
        public string DisplayText
        {
            get => displayText;
            private set
            {
                if (displayText != value)
                {
                    displayText = value;
                    OnPropertyChanged();

                    ((Command)DeleteCharCommand).ChangeCanExecute();
                }
            }
        }

        public KeypadViewModel()
        {
            AddCharCommand = new Command<string>(key => DisplayText += key);

            DeleteCharCommand =
                new Command(
                    () => DisplayText = DisplayText.Substring(0, DisplayText.Length - 1),
                    () => DisplayText.Length > 0
                );
        }


        public void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

