using System;
using System.Reflection;
using System.Collections.Generic;


public class Planet
{
    public string planetName { get; set; }
    public int Id { get; set; }

    public Planet(String name, int distance)
    {
        planetName = name;
        Id = distance;
    }

    public Planet() { }
}

public class Example
{
    public static void Main()
    {
        List<Planet> planets = new List<Planet>();
        Planet jupiter = new Planet("Jupiter", 3);
        Planet jupiter1 = new Planet("sdf", 5);
        Planet jupiter2 = new Planet("xcv", 8);
        Planet jupiter3 = new Planet("vdf", 2);
        planets.Add(jupiter);
        planets.Add(jupiter1);
        planets.Add(jupiter2);
        planets.Add(jupiter3);

        GetPropertyValues(planets);
    }

    private static void GetPropertyValues<T>(List<T> planets)
    {
        T newEl = planets.Find(x => int.Parse(x.GetType().GetProperty("Id").GetValue(x).ToString()) == 48);
        
        Console.WriteLine(newEl);

        Console.ReadLine();

    }
}