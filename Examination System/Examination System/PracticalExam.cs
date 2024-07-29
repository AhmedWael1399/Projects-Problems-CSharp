using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    internal class PracticalExam : Exam
    {
        public PracticalExam(int _TimeOfExam, int _NumberOfQuestions, Question[] _Questions) : base(_TimeOfExam, _NumberOfQuestions, _Questions)
        {
        }

        public override void ShowExam()
        {
            int score = 0;
            int totalScore = 0;
            Answer[] userAnswers = new Answer[Questions?.Length ?? 0];

            StartExam();

            for (int i = 0; i < Questions?.Length; i++)
            {

                Question question = Questions[i];
                Console.WriteLine($"{question.Header} (Mark {question.Mark})\n{question.Body}");
                if (question.AnswerList != null)
                {
                    Console.WriteLine();
                    for (int j = 0; j < question.AnswerList.Length; j++)
                    {
                        Console.WriteLine($"{j}. {question.AnswerList[j].AnswerText}");
                    }
                }

                string promptMessage = "Please choose the correct answer Id: ";
                int userAnswerId;

                Console.Write(promptMessage);


                while (!int.TryParse(Console.ReadLine(), out userAnswerId) || userAnswerId < 0 || userAnswerId >= question.AnswerList?.Length)
                {
                    Console.WriteLine("Invalid choice. Please enter a valid option");
                    Console.Write(promptMessage);
                }

                userAnswers[i] = question.AnswerList?[userAnswerId]!;

                if (userAnswers[i].AnswerId == question.RightAnswer?.AnswerId)
                {
                    score += question.Mark;
                }

                totalScore += question.Mark;
                Console.WriteLine();
            }

            EndExam();

            Console.Clear();
            for (int i = 0; i < Questions?.Length; i++)
            {
                Question question = Questions[i];
                Console.WriteLine($"Question {i + 1}: {question.Body}");

                if (userAnswers[i] != null)
                {
                    Console.WriteLine($"Your answer => {userAnswers[i].AnswerText}");
                }
                Console.WriteLine($"Right answer => {question.RightAnswer?.AnswerText}");
                Console.WriteLine();
            }

            TimeSpan totalTimeTaken = GetElapsedTime();
            TimeSpan remainingTimeAfterExam = GetRemainingTime();

            Console.WriteLine($"Your Grade is {score} out of {totalScore}");
            Console.WriteLine($"Remaining time: {remainingTimeAfterExam}");
            Console.WriteLine("Thank you");
        }
    }
}
