using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Maui5eClient.Models;

public class Subclass : INotifyPropertyChanged
{
    private string _subclassName;
    [JsonPropertyName("name")]
    public string SubclassName
    {
        get => _subclassName;
        set
        {
            if (value == _subclassName) return;
            _subclassName = value;
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SubclassName))); 
        }
    }

    [JsonPropertyName("desc")]
    public List<string> Description { get; set; }
   
    public event PropertyChangedEventHandler PropertyChanged;
}