using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Kangelane
{
    private string nimi;
    private string asukoht;

    public string Nimi
    {
        get { return nimi; }
        set
        {
            if (value.Length > 2)
                nimi = value;
        }
    }
    public string Asukoht
    {
        get { return asukoht; }
        set
        {
            if (value == "Tallnn" || value == "Tartu" || value == "Narva")
                asukoht = value;
        }
    }
}