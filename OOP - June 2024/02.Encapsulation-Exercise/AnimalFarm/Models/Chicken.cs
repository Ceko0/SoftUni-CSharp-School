﻿namespace AnimalFarm.Models;
public class Chicken
{
    private const int MinAge = 0;
    private const int MaxAge = 15;

    private string name;
    private int age;

    public Chicken(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be empty.");
        if (age < MinAge || age > MaxAge) throw new ArgumentException($"Age should be between {MinAge} and {MaxAge}.");
        this.name = name;
        this.age = age;
    }

    public string Name { get => name; }

    public int Age { get => this.age; }

    public double ProductPerDay
    {
        get
        {
            return this.CalculateProductPerDay();
        }
    }

    private double CalculateProductPerDay()
    {
        switch (this.Age)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                return 1.5;
            case 4:
            case 5:
            case 6:
            case 7:
                return 2;
            case 8:
            case 9:
            case 10:
            case 11:
                return 1;
            default:
                return 0.75;
        }
    }
}
