
using SQLite;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Collections.Generic;

namespace Prodactive_App2.Models;

[Table("AddNewTab")]
public class AddNewTab
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Cnt { get; set; }

    public string Name { get; set; }

    public  string Icon { get; set; }
    public string Description { get; set; }

    public string Color_name { get; set; }

    public string Minute { get; set; }

    public string Seconds { get; set; }
    public string Hour { get; set; }

    public int Ok { get; set; }

    public string SelectedOption { get; set; }
}