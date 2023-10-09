using SQLite;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Collections.Generic;

namespace Prodactive_App2.Models;

[Table("PickerTab")]
public class PickerTab
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Cnt { get; set; }

    public string Name { get; set; }

    public string Minute { get; set; }

    public string Seconds { get; set; }
    public string Hour { get; set; }

    public int Ok { get; set; }

    public string SelectedOption { get; set; }
}