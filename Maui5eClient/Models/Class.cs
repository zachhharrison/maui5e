using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Maui5eClient.Models;

public class Class : INotifyPropertyChanged
{
    public string Index { get; set; }
    private string _className;
    [JsonPropertyName("name")]
    public string ClassName
    {
        get => _className;
        set
        {
            if (value == _className) return;
            _className = value;
            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClassName)));
        }
    }
    public List<Subclasses> Subclasses {get; set; }
    
    public event PropertyChangedEventHandler PropertyChanged;

}