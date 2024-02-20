using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ingresa los elementos de la lista separados por un carácter (por ejemplo, espacio o coma):");
        string input = Console.ReadLine();

        Console.WriteLine("Ingresa el número de rotaciones hacia la izquierda:");
        if (int.TryParse(Console.ReadLine(), out int rotations))
        {
            List<int> integerList = ParseInput(input);

            rotations = rotations % integerList.Count;

            List<int> rotatedList = new List<int>();

            for (int i = rotations; i < integerList.Count; i++)
            {
                rotatedList.Add(integerList[i]);
            }

            for (int i = 0; i < rotations; i++)
            {
                rotatedList.Add(integerList[i]);
            }

            Console.WriteLine("Lista resultante después de las rotaciones:");
            foreach (int num in rotatedList)
            {
                Console.Write(num + " ");
            }
        }
        else
        {
            Console.WriteLine("Error: Ingresa un número entero válido para las rotaciones.");
        }
    }

    static List<int> ParseInput(string input)
    {
        string[] inputArray = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        List<int> integerList = new List<int>();

        foreach (string str in inputArray)
        {
            if (int.TryParse(str, out int num))
            {
                integerList.Add(num);
            }
            else
            {
                Console.WriteLine("Error: Ingresa solo números enteros.");
                Environment.Exit(1);
            }
        }

        return integerList;
    }
}



//Recursion 
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> listaOriginal = new List<int> { 1, 2, 3, 4, 5 };
        List<int> listaInvertida = InvertirLista(listaOriginal);

        Console.WriteLine("Lista Original: " + string.Join(", ", listaOriginal));
        Console.WriteLine("Lista Invertida: " + string.Join(", ", listaInvertida));
    }

    static List<T> InvertirLista<T>(List<T> listaOriginal)
    {
        // Caso base: si la lista es nula o tiene un solo elemento, devolver la lista original
        if (listaOriginal == null || listaOriginal.Count <= 1)
        {
            return new List<T>(listaOriginal);
        }

        // Invertir la lista y agregar el primer elemento al principio
        List<T> listaInvertidaRestante = InvertirLista(listaOriginal.GetRange(0, listaOriginal.Count - 1));
        listaInvertidaRestante.Insert(0, listaOriginal[listaOriginal.Count - 1]);

        return listaInvertidaRestante;
    }
}

