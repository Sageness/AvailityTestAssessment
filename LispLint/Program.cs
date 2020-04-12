using System;
using System.Collections.Generic;
using System.Linq;
using LispLint.Helpers;

namespace LispLint
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Log.LogMsg("Hello! Welcome to the first part of the Availity Technical Assessment - The Lisp Parentheses Linter!\n");

            while (true)
            {
                Log.LogMsg("If you would like to have a lisp string checked, please paste the string that you would like validated below \nand I'll tell you whether or not the parentheses are balanced.\nOtherwise, just close this window and we'll see each other some other time!");
                //Perform validation
                ValidateLispCode();
            }
        }

        /// <summary>
        /// This does all of the legwork for the app and is what gets called with every user input loop
        /// </summary>
        private static void ValidateLispCode()
        {
            Log.LogMsg("\nNote: Since we're working with multi-line and multi-paste inputs, you will need to add \"exit\" to on its own line after \nwhatever you paste in so that the code knows when to stop scanning lines.", Log.LogType.Success);
            string lispString = string.Empty;
            string line;
            //Collect input and handle potential multi-line pastes.
            Input:
            line = Console.ReadLine() ?? string.Empty;
            if (line.ToLower() != "exit")
            {
                lispString += line;
                goto Input;
            }

            //Check if the user entered a string. If not, it throws a bit of shade and asks them to try again. 
            CheckLispStringLength(lispString);

            //Perform validation
            if (IsParenthesesBalanced(lispString))
                Log.LogMsg("Perfectly balanced... As all things should be.", Log.LogType.Success);
            else
                Log.LogMsg("Oh no! It looks like there are imbalanced parentheses in what you pasted in! Please correct it and re-submit!", Log.LogType.Fail);

            // Spacer line to clearly separate our various validation runs
            Log.LogMsg("\n    ---------------------------------------------------------------    \n");
        }

        /// <summary>
        /// 50% null checker, 50% shade generator.
        /// </summary>
        /// <param name="lispString">string that we'll be checking</param>
        private static void CheckLispStringLength(string lispString)
        {
            while (true)
            {
                if (!string.IsNullOrWhiteSpace(lispString)) return;

                //Give a different insult based on the day of the week.
                switch (DateTime.Now.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                        Log.LogMsg("On the seventh day, the lord said \"Let there be a Lisp string for me to validate!\" ...and it stack overflowed.", Log.LogType.Fail);
                        break;
                    case DayOfWeek.Monday:
                        Log.LogMsg("Listen, no one wants to be here on a Monday. The least you could do is give me a bloody string to work with here!", Log.LogType.Fail);
                        break;
                    case DayOfWeek.Tuesday:
                        Log.LogMsg("Imagine sitting there reading this code instead of having tacos on a Tuesday... Anyways, please give me a string to validate so I can stop thinking about it!", Log.LogType.Fail);
                        break;
                    case DayOfWeek.Wednesday:
                        Log.LogMsg("Halfway through the work week and already skimping me on the string you want me to validate? tsk tsk...", Log.LogType.Fail);
                        break;
                    case DayOfWeek.Thursday:
                        Log.LogMsg("For Throwback Thursday, I remember this time when you actually gave me a lisp string to validate... Those were the days!", Log.LogType.Fail);
                        break;
                    case DayOfWeek.Friday:
                        Log.LogMsg("Hey, I know it's Friday and all but I need you to give me a lisp string to validate so I can make my union mandated beer appointment!", Log.LogType.Fail);
                        break;
                    case DayOfWeek.Saturday:
                        Log.LogMsg("Working on a Saturday? I would call you an over-achiever, but you also didn't give me anything to validate so...", Log.LogType.Fail);
                        break;
                    default:
                        throw new Exception("Today doesn't exist. This is a problem.");
                }

                lispString = Console.ReadLine();
            }
        }
        
        /// <summary>
        /// Our meat and potatoes. This is what checks the string that the user entered and uses the C# Stack library to check for balanced parentheses. 
        /// </summary>
        /// <returns>boolean value based on whether or not the lisp string has balanced parentheses</returns>
        private static bool IsParenthesesBalanced(string lispString)
        {
            //Declare a dictionary to hold our parentheses. We can add any character 'pair' as needed later such as [], {}, <>, etc. 
            var validationPairs = new Dictionary<char, char> { { '(', ')' } };

            var parentheses = new Stack<char>();

            try
            {
                // Iterate through each character in the input string
                foreach (var c in lispString)
                {
                    // Check if char is an 'opening' parenthesis. Add it to our stack if it is.
                    if (validationPairs.Keys.Contains(c))
                        parentheses.Push(c);

                    // Check for 'closing' parenthesis
                    else if (validationPairs.Values.Contains(c))
                    {
                        // If found, let's try to find the matching 'opening' parenthesis and remove it
                        if (c == validationPairs[parentheses.Peek()])
                            parentheses.Pop(); 
                        else
                            // if not, its an unbalanced string
                            return false;
                    }
                }
            }
            //If we hit a 'closing' parenthesis before a matching 'opening' parenthesis, an exception will be thrown which means our lisp string is unbalanced. 
            catch { return false; }

            // Since we remove matching pairs using the Pop method above, we shouldn't have anything in the stack at this point. 
            //Any remaining items in the stack means there was a mismatch and we're unbalanced. 
            return !parentheses.Any();
        }
    }
}
