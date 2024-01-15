using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {Name}, Age: {Age}");
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Interactive Object Interaction in C#");

        // Interactive menu
        while (true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Create a new person");
            Console.WriteLine("2. Display information about a person");
            Console.WriteLine("3. Exit");

            Console.Write("Enter your choice (1-3): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreatePerson();
                    break;
                case "2":
                    DisplayPersonInfo();
                    break;
                case "3":
                    Console.WriteLine("Exiting the program. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 3.");
                    break;
            }
        }
    }

    static void CreatePerson()
    {
        Console.Write("Enter the person's name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the person's age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        Person newPerson = new Person { Name = name, Age = age };
        Console.WriteLine("Person created successfully!");
    }

    static void DisplayPersonInfo()
    {
        // Assuming we have a globally accessible Person object (for simplicity)
        if (newPerson != null)
        {
            newPerson.DisplayInfo();
        }
        else
        {
            Console.WriteLine("No person created yet. Please create a person first.");
        }
    }

    // Global variable to store the created Person object
    static Person newPerson;

    public class SceneChanger : MonoBehaviour
    {
        // You can call this method to change to a specific scene by name
        public void ChangeToScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }

        // Example of usage in Unity's UI Button
        public void OnButtonClick(string sceneName)
        {
            ChangeToScene(sceneName);
        }
    }
}

