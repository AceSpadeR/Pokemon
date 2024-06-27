using PokemonGame.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Media;

namespace PokemonGame
{
    /// <summary>
    /// User information
    /// </summary>
    public class User
    {
        public string sName { get; set; }
        public int iCorrect { get; set; }
        public int iIncorrect { get; set; }
        public string sOutCome { get; set; }

    }
    /// <summary>
    /// Game calculations
    /// </summary>
    public class GamePlay
    {
        char cMathType;
        int iNum1;
        int iNum2;
        string sQuestion;
        public int iCount;
        private User user1;
        private User user2;
        private string timer;
        /// <summary>
        /// Constructor
        /// </summary>
        public GamePlay(char MathType, string sPlayerName1, string sPlayerName2)
        {
            try { 
                //New Users
            user1 = new User();
            user2 = new User();
            cMathType = MathType;
            user1.sName = sPlayerName1;
            user2.sName = sPlayerName2;
            user1.iCorrect = 0;
            user2.iCorrect = 0;
            user1.iIncorrect = 0;
            user2.iIncorrect = 0;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
        /// <summary>
        /// gets questions
        /// </summary>
        /// </return> quesiton
        public string GetQuestion()
        {
            try { 
                //Gets random for questions
            var random = new Random();
            iCount++;

            switch (cMathType)
            {
                case '+':
                        iNum1 = random.Next() % 10 + 1;
                        iNum2 = random.Next() % 10 + 1;
                        sQuestion = iNum1 + " + " + iNum2 + " = ";
                    return iCount.ToString() + ":   " + sQuestion;
                case '-':
                        iNum1 = random.Next() % 10 + 1;
                    do {
                        iNum2 = random.Next() % 10 + 1;
                    } while (iNum1 < iNum2);
                        sQuestion = iNum1 + " - " + iNum2 + " = ";
                    return iCount.ToString() + ":   " + sQuestion;
                case '*':
                    iNum1 = random.Next() % 10 + 1;
                    iNum2 = random.Next() % 10 + 1;
                    sQuestion = iNum1 + " * " + iNum2 + " = ";
                    return iCount.ToString() + ":   " + sQuestion;
                case '/':
                    iNum1 = random.Next() % 10 + 1;
                    do
                    {
                        iNum2 = random.Next() % 10 + 1;
                    } while (iNum1 % iNum2 != 0);
                    sQuestion = iNum1 + " / " + iNum2 + " = ";
                    return iCount.ToString() + ":   " + sQuestion;
                default: return iCount.ToString() + ":   " + sQuestion;

            }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
;
        }
        /// <summary>
        /// gets answer
        /// </summary>
        /// </return> answer
        public string GetAnswer()
        {
            try { 
                //get answers from numbers
                switch (cMathType)
                {
                    case '+':
                        return (iNum1 + iNum2).ToString();

                    case '-':
                        return (iNum1 - iNum2).ToString();
                    case '*':
                        return (iNum1 * iNum2).ToString();
                    case '/':
                        return (iNum1 / iNum2).ToString();
                    default: return "0";

                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// gets winner
        /// </summary>
        /// </return> winner
        public string GetWinner(string ans1, string ans2)
        {
            try {
            if (ans1 == GetAnswer())
                { user1.iCorrect += 1; }
            if (ans2 == GetAnswer())
                { user2.iCorrect += 1; }
            if ((ans1 == GetAnswer()) && (ans2 == GetAnswer())) 
            {
                return "Tie";
            }
            else if (ans1 == GetAnswer() && ans2 != GetAnswer())
            {
                return "Player1 Wins";
            }
            else if (ans1 != GetAnswer() && ans2 == GetAnswer())
            {
                return "Player2 Wins";
            }
            else
            {
                return "Wrong";
            }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// gets User
        /// </summary>
        /// </return> stats
        public string GetUser(int Player)
        {
            //get outcome
           if(user1.iCorrect > user2.iCorrect) 
            {
                user1.sOutCome = "Win";
                user2.sOutCome = "Lose";
            }
           if(user1.iCorrect == user2.iCorrect)
            {
                user1.sOutCome = "Tie";
                user2.sOutCome = "Tie";
            }
            else
            {
                user1.sOutCome = "Lose";
                user2.sOutCome = "Win";
            }
           //get string
           if (Player == 1)
            {
                return user1.sName + "  Correct: "+ user1.iCorrect+ "  Incorrect: " + user1.iIncorrect+ "  OutCome: " + user1.sOutCome;
            }
            else
            {
                return user2.sName + "  Correct: " + user2.iCorrect + "  Incorrect: " + user2.iIncorrect + "  OutCome: " + user2.sOutCome;
            }
        }
        /// <summary>
        /// sets timer
        /// </summary>
        public void SetTime(string time)
        {
            timer = time;
        }
        /// <summary>
        /// gets time
        /// </summary>
        /// </return> timer
        public string getTime()
        {
            return timer;
        }

    }




}
