using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace WpfApp1;
public class DoorGenerator
{
    /*generates a game. 3 doors. One of which has the win condition*/
	public DoorGenerator()
	{

        Random rnd = new Random();
        car = rnd.Next(3);
        for (int i = 0; i < 3; i++)
        {
            if (i == car)
            {
                doors.Add(true);
            }
            else
            {
                doors.Add(false);
            }
        }

    }
    int car = 0;
    List<bool> doors = new List<bool>();
    public List<bool> _doors
    {
        get { return doors; }
        set { doors = value; }
    }
    /* keeping track which doors are still in the game. The first goat gets dropped by the gaminglogic.gaming method*/
    List<int> numbers = new List<int> ( new int[] { 1, 2, 3 });
    public List<int> _numbers
    {
        get { return numbers; }
        set { numbers = value; }
    }
}
