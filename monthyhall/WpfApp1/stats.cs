using System;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Xml.Serialization;

namespace WpfApp1;
public class Statistics
{
    public Statistics()
    {

    }
    /*basic statistic class that keeps the win/loss ratio of the options of the montyhall problem and gives to the mainwindow to manipulate the graphical feedback*/
    int winChange;
    int countChange;
    double ratioChange;

    int winStay;
    int countStay;
    double ratioStay;

    public int _winChange
    {
        get 
        { 
            return winChange; 
        }
        private set
        {
            winChange = value;
        }
    }
    public int _countChange
    {
        get
        {
            return countChange;
        }
        private set
        {
            countChange = value;
        }
    }
    public double _ratioChange
    {
        get
        {
            return ratioChange;
        }
        set
        {
            ratioChange = value;
        }
    }
    public int _winStay
    {
        get
        {
            return winStay;
        }
        private set
        { 
            winStay = value;
        }
    }
    public int _countStay
    {
        get
        {
            return countStay;
        }
        private set
        { 
            countStay = value;
        }
    }
    public double _ratioStay
    {
        get
        {
            return ratioStay;
        }
        set
        {
            ratioStay = value;
        }
    }
    /*evaluates the win or loss and adds it to the relevant stat*/
    public void Accessor(bool mode, bool outcome)
    {
        if (mode == false)
        {
            _countChange += 1;
            if (outcome==true)
            {
                _winChange += 1;

            }
            _ratioChange = (double)_winChange / (double)_countChange;
        }
        else if (mode==true)
        {
            _countStay += 1;
            if (outcome == true)
            {
                _winStay += 1;
            }
            _ratioStay = (double)_winStay / (double)_countStay;
        }
    }
}