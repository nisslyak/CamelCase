using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Globalization;

class Solution
{
    private static void CreateOrSplitInput()
    {
        List<string> inputLines = new List<string>();

        string line;
        while ((line = Console.ReadLine()) != null && line != "")
        {
            inputLines.Add(line);
        }

        for (int i = 0; i < inputLines.Count; i++)
        {
            if (inputLines[i].StartsWith("S"))
            {
                if (inputLines[i][2] == 'M')
                {
                    string method;

                    method = SplitText(inputLines[i]);
                    method = RemoveBrackets(method);
                    Console.WriteLine(method);
                }

                if (inputLines[i][2] == 'C' || inputLines[i][2] == 'V')
                {
                    string nameOfTheClass;

                    nameOfTheClass = SplitText(inputLines[i]);

                    Console.WriteLine(nameOfTheClass);
                }
            }

            else if (inputLines[i].StartsWith("C"))
            {
                if (inputLines[i][2] == 'M')
                {
                    string method = CombineText(inputLines[i]);
                    Console.WriteLine(method + "()");
                }
                else if (inputLines[i][2] == 'V')
                {
                    string variable = CombineText(inputLines[i]);
                    Console.WriteLine(variable);
                }
                else if (inputLines[i][2] == 'C')
                {
                    string nameOfTheClass = CombineText(inputLines[i]);

                    nameOfTheClass = char.ToUpper(nameOfTheClass[0]) + nameOfTheClass.Substring(1);
                    Console.WriteLine(nameOfTheClass);
                }
            }
        }
    }
    public static string CombineText(string input)
    {

        string[] updatedInput = input.Split(new string[] { " " }, StringSplitOptions.None);
        string combinedText = updatedInput[0].Substring(4);

        for (int i = 1; i < updatedInput.Length; i++)
        {
            string methodText = updatedInput[i];
            methodText = methodText.Substring(0, 1).ToUpper() + methodText.Substring(1); 
            combinedText = combinedText + methodText;
        }
        return combinedText;
    }


    public static string SplitText(string input)
    {

        string[] updatedInput = input.Split(new string[] { " " }, StringSplitOptions.None);
        string splitText;
        updatedInput = Regex.Split(input.Substring(4), @"(?<!^)(?=[A-Z])");

        splitText = string.Join(" ", updatedInput).ToLower();

        return splitText;
    }


    public static string RemoveBrackets(string input)
    {
        return input.Substring(0, input.Length - 2);
    }
    public static string SplitClass(string input)
    {
        string[] updatedInput = input.Split(new string[] { " " }, StringSplitOptions.None);
        string splitText = null;
        updatedInput = Regex.Split(input.Substring(4), @"(?<!^)(?=[A-Z])");

        splitText = string.Join(" ", updatedInput);

        return splitText.ToLower();
    }






    public static void Main(string[] args)
    {
        CreateOrSplitInput();
    }

}
