using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace WpfApp1;
public class GameLogic
{
    public GameLogic()
    {

    }
    int step = 0;

    /*first step to eliminate one of the lose options*/
    public string Gaming(string choice, DoorGenerator listing)
    {
        Random rnd = new Random();
        int reveal = 0;
        string output = "";
        Uri uri = new Uri("/goat.jpg", UriKind.Relative);
        while (step == 0)
        {
            reveal = rnd.Next(3);
            if ("door" + (reveal + 1) != choice && listing._doors[reveal] == false)
            {
                output = "door" + (reveal + 1);
                listing._doors.RemoveAt(reveal);
                listing._numbers.RemoveAt(reveal);
                step++;
            }

        }
        return output;
    }
    /*resolution of the desicion whenever to stay or to change the door*/
    public bool FinalChoice(string choice, DoorGenerator listing)
    {
        char nummero = choice[4];
        int choicefinal = (int)Char.GetNumericValue(nummero);
        int tracker = listing._numbers.IndexOf(choicefinal);
        if (listing._doors[tracker] == true)
        {
            return true;

        }
        else
        {
            return false;
        }
    }
}