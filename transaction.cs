using System;
using System.Runtime;
using Microsoft.VisualBasic;

public class Transaction
{
    public DateTime DateAndTime { get; set; }
    public int Amount { get; set; }

    public string Type { get; set; }


    public Transaction(int Amount, string Type)
    {
        DateAndTime = DateTime.Now;
        Amount = amount;
        Type = type;
    }

    public override string ToString()
    {
        return $"{DateTime.Now}: {Type} på {Amount} kr"; //Visar vad som händer vid en Insättning/Uttag
    }







}