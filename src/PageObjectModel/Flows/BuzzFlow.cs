using PageObjectModel.Pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PageObjectModel.Flows
{
    public class BuzzFlow
    {
        private BuzzPage _page;
        public BuzzFlow(BuzzPage page)
        {
            _page = page;
        }

        public void ClickBuzzMenu()
        {
            _page.BuzzMenu.Click();
        }

        public void EnterBuzzPostBox(string postText)
        {
            char ch = 'a';
            switch (Char.ToLower(ch))
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    Console.WriteLine("Vowel");
                    break;
                default: 
                    Console.WriteLine("Not a vowel");
                    break ;
            }
            _page.BuzzPostBox.SendKeys(postText);
        }
        public void EnterBuzzPostBox(char[] postText)
        {
            string printValue = new string(postText);
            Array.Sort(postText);
            string value1 = new string(postText);
            var v1 = value1.ToLower();
            StringBuilder sb = new StringBuilder();
            foreach (char c in v1)
            {
                if (sb.ToString().IndexOf(c) == -1)
                {
                    sb.Append(c);
                }
            }
            sb.Replace(" ", "");
            if (sb.Length == 26)
            {
                _page.BuzzPostBox.SendKeys(printValue.ToString());
                _page.BuzzPostBox.SendKeys("\nThe text provided is a panagram text. \n");
            }
            else
            {
                _page.BuzzPostBox.SendKeys(printValue.ToString());
                _page.BuzzPostBox.SendKeys("\nThe text provided is not a panagram text. \n");
            }
            
        }
        //Enter text box with pyramid
        public void EnterBuzzPostBox(int numberOfRowsForPyramid)
        {
            int space, number;
            StringBuilder sb = new StringBuilder();
            for(int i = 1; i <= numberOfRowsForPyramid; i++)
            {
                for (space = 1; space <= (numberOfRowsForPyramid - i); space++) // Loop For Space  
                    sb.Append(" ");
                for (number = 1; number <= i; number++) //increase the value  
                    sb.Append('*');
                for (number = (i - 1); number >= 1; number--) //decrease the value  
                    sb.Append('*');
                sb.AppendLine();
            }
            _page.BuzzPostBox.SendKeys(sb.ToString());
        }
        // Enter text box with anagram text
        public void EnterBuzzPostBox(string variable1, string variable2)
        {
            char[] ch1 = variable1.ToLower().ToCharArray();
            char[] ch2 = variable2.ToLower().ToCharArray();
            Array.Sort(ch1);
            Array.Sort(ch2);
            string val1 = new string(ch1);
            string val2 = new string(ch2);
            if(val1 == val2)
            {
                _page.BuzzPostBox.SendKeys("\n" + variable1 + " & " + variable2 + " are anagram of each other.\n");
            }
            else
            {
                _page.BuzzPostBox.SendKeys("\n" + variable1 + " & " + variable2 + " are not anagram of each other. \n");
            }
        }
        public void EnterBuzzPostBox(string postText, bool doYouWantToCheckPanagram)
        {
            if(doYouWantToCheckPanagram == true)
            {
                string value = checkPangram(postText).ToString();
                _page.BuzzPostBox.SendKeys(value);
            }
            else
            {
                _page.BuzzPostBox.SendKeys(postText);
            }
        }
        static bool checkPangram(string str)
        {
            return str.ToLower().Where(ch => Char.IsLetter(ch)).GroupBy(ch => ch).Count() == 26;
        }

        public void EnterBuzzPostBox()
        {
            ArrayList man = new ArrayList();
            man.Add("Sam");
            man.Add(35);
            man.Add(75.18);
            man.Add(true);

            man[0] = "Sam Wilson";
            _page.BuzzPostBox.SendKeys("Name: " + man[0] + "\nAge: " + man[1] + "\n Weight: " + man[2] + "\nMarried: " + man[3] + "\n");

            man.Remove(true);
            man.Add(false);

            _page.BuzzPostBox.SendKeys("Name: " + man[0] + "\nAge: " + man[1] + "\n Weight: " + man[2] + "\nMarried: " + man[3] + "\n");

            Stack<string> otherUsers = new Stack<string>();
            otherUsers.Push("Bob Wilson");
            otherUsers.Push("Tom Wilson");
            otherUsers.Push("Tam Wilson");
            otherUsers.Push("Lanesra");
            otherUsers.Push("Fed Wilson");

            int count = otherUsers.Count;

            for (int i = 0; i < count; i++)
            {
                string tempString = otherUsers.Peek();
                if (tempString == "Lanesra")
                {
                    _page.BuzzPostBox.SendKeys(tempString + " : This is the only lady name among the stack. \n");
                }
                else
                {
                    _page.BuzzPostBox.SendKeys(tempString + " : This is one of the other users among the stack. \n");
                }
                otherUsers.Pop();
            }

            Queue<int> numbers = new Queue<int>();
            numbers.Enqueue(10);
            numbers.Enqueue(15);
            numbers.Enqueue(20);
            numbers.Enqueue(25);

            count = numbers.Count;

            for(int i = 0; i < count;i++)
            {
                int tempNo = numbers.Peek();
                if(tempNo % 2 == 0)
                {
                    _page.BuzzPostBox.SendKeys("The number " + tempNo + " is Even number. \n");
                }
                else
                {
                    _page.BuzzPostBox.SendKeys("The number " + tempNo + " is Odd number. \n");
                }
                numbers.Dequeue();
            }
            numbers.Enqueue(40);
            if (numbers.Contains(40))
            {
                _page.BuzzPostBox.SendKeys("New number was added and contains the number: " + numbers.Peek() + "\n");
            }

        }

        public void ClickSaveButton1()
        {
            _page.SaveButton1.Click();
        }

        public void ClickLikeButton()
        {
            _page.LikeButton.Click();
        }
    }
}
