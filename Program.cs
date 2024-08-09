//using System;
// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

int count = 20;
int firstNumber = 0;
int secondNumber = 1;
int thirdNumber = 1;
Console.WriteLine("This is a Fibonacci Sequence of " + count + " numbers.");
for (int i = 0; i < count; i++)
{
    if (i == count - 1)
    {
        Console.WriteLine(firstNumber + ".");
    }
    else
    {
        Console.Write(firstNumber + ", ");
    }
    firstNumber = secondNumber;
    secondNumber = thirdNumber;
    thirdNumber = firstNumber + secondNumber;
}

count = 2;
for (int i = 0; i < count; i++)
{
    Console.WriteLine();
}

//string reversal program

Console.WriteLine("Below text would be reversed");
string reversalText = "This is the text that will be reversed";
Console.WriteLine(reversalText);
char[] charArray = reversalText.ToCharArray();
string reversedText = string.Empty;
for (int i = charArray.Length - 1; i > -1; i--)
{
    reversedText += charArray[i];
}

Console.WriteLine("Below is the reversed text for above value.");
Console.WriteLine(reversedText);
for (int i = 0; i < count; i++)
{
    Console.WriteLine();
}

//string reversal program for each word in a sentence


Console.WriteLine("Below text letters of each word would be reversed.");
reversalText = "My name is Vishal";
Console.WriteLine(reversalText);

string reverseLetters = string.Join(" ", reversalText.Split(' ').Select(x => new string(x.Reverse().ToArray())));
Console.WriteLine("The reversed output for the above input is --> " + reverseLetters);

for (int i = 0; i < count; i++)
{
    Console.WriteLine();
}

// Swapping numbers without using a third variable

int numberA = 10;
int numberB = 20;

Console.WriteLine("Number A is :" + numberA + ". Number B is :" + numberB);

numberA = numberA + numberB; //output is 30
numberB = numberA - numberB; //output is 10 since value of A is updated to 30
numberA = numberA - numberB; //output is 20 since value of B is updated to 10

Console.WriteLine("After Swapping the number without using a third variable.");
Console.WriteLine("Number A is :" + numberA + ". Number B is :" + numberB);


for (int i = 0; i < count; i++)
{
    Console.WriteLine();
}


// Check if number is odd or even.


int[] list1 = { 101, 258, 355, 462, 500, 651, 798 };
Console.WriteLine("Checking if the numbers provided in the list is either odd or even.");

foreach(var i1 in list1)
{
    if (i1 % 2 == 0)
    {
        Console.WriteLine("This is an even number: " + i1);
    }
    else
    {
        Console.WriteLine("This is an odd number: " + i1);
    }
}


for (int i = 0; i < count; i++)
{
    Console.WriteLine();
}


// Check if given string is a palindrome.

string inputText = "MadAm";
string palindrome = inputText.ToLower();
Boolean result = true;
int lengthOfPalindrome = palindrome.Length;
for(int i2  = 0; i2 < lengthOfPalindrome/2; i2++)
{
    if (palindrome.ElementAt(i2) != palindrome.ElementAt(lengthOfPalindrome - i2 - 1))
    {
        result = false;
        break;
    }
}
if(result == true)
{
    Console.WriteLine("The word " + inputText + " is a palindrome");
}
else
{
    Console.WriteLine("The word " + inputText + " is not a palindrome");
}


for (int i = 0; i < count; i++)
{
    Console.WriteLine();
}



