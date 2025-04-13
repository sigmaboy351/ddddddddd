﻿using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Product> inventory = new List<Product>();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nWybierz opcję:");
            Console.WriteLine("1. Dodaj produkt");
            Console.WriteLine("2. Usuń produkt");
            Console.WriteLine("3. Wyświetl listę produktów");
            Console.WriteLine("4. Aktualizuj produkt");
            Console.WriteLine("5. Oblicz wartość magazynu");
            Console.WriteLine("6. Wyjście");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddProduct(inventory);
                    break;
                case "2":
                    RemoveProduct(inventory);
                    break;
                case "3":
                    DisplayProducts(inventory);
                    break;
                case "4":
                    UpdateProduct(inventory);
                    break;
                case "5":
                    CalculateInventoryValue(inventory);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                    break;
            }
        }
    }

    static void AddProduct(List<Product> inventory)
    {
        Console.Write("Podaj nazwę produktu: ");
        string name = Console.ReadLine();

        Console.Write("Podaj ilość: ");
        if (!int.TryParse(Console.ReadLine(), out int quantity))
        {
            Console.WriteLine("Nieprawidłowa ilość. Operacja anulowana.");
            return;
        }

        Console.Write("Podaj cenę: ");
        if (!double.TryParse(Console.ReadLine(), out double price))
        {
            Console.WriteLine("Nieprawidłowa cena. Operacja anulowana.");
            return;
        }

        inventory.Add(new Product { Name = name, Quantity = quantity, UnitPrice = price });
        Console.WriteLine("Produkt dodany!");
    }

    static void RemoveProduct(List<Product> inventory)
    {
        Console.Write("Podaj nazwę produktu: ");
        string name = Console.ReadLine();

        Product productToRemove = inventory.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (productToRemove != null)
        {
            inventory.Remove(productToRemove);
            Console.WriteLine("Produkt usunięty!");
        }
        else
        {
            Console.WriteLine("Nie znaleziono produktu o podanej nazwie.");
        }
    }

    static void DisplayProducts(List<Product> inventory)
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("Magazyn jest pusty.");
            return;
        }

        Console.WriteLine("\nLista produktów:");
        foreach (var product in inventory)
        {
            Console.WriteLine($"Nazwa: {product.Name}, Ilość: {product.Quantity}, Cena: {product.UnitPrice:C}");
        }
    }

    static void UpdateProduct(List<Product> inventory)
    {
        Console.Write("Podaj nazwę produktu: ");
        string name = Console.ReadLine();

        Product productToUpdate = inventory.Find(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (productToUpdate != null)
        {
            Console.WriteLine("Co chcesz zaktualizować?");
            Console.WriteLine("1. Ilość");
            Console.WriteLine("2. Cenę");
            Console.WriteLine("3. Oba");

            string option = Console.ReadLine();
            if (option == "1" || option == "3")
            {
                Console.Write("Podaj nową ilość: ");
                if (int.TryParse(Console.ReadLine(), out int newQuantity))
                {
                    productToUpdate.Quantity = newQuantity;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa ilość. Operacja anulowana.");
                }
            }
            if (option == "2" || option == "3")
            {
                Console.Write("Podaj nową cenę: ");
                if (double.TryParse(Console.ReadLine(), out double newPrice))
                {
                    productToUpdate.UnitPrice = newPrice;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowa cena. Operacja anulowana.");
                }
            }

            Console.WriteLine("Produkt zaktualizowany.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono produktu o podanej nazwie.");
        }
    }

    static void CalculateInventoryValue(List<Product> inventory)
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("Magazyn jest pusty.");
            return;
        }

        double totalValue = 0;
        foreach (var product in inventory)
        {
            totalValue += product.Quantity * product.UnitPrice;
        }
        Console.WriteLine($"Całkowita wartość magazynu: {totalValue:C}");
    }
}

class Product
{
    public string Name { get; set; }
    public int Quantity { get; set; }
    public double UnitPrice { get; set; }
}