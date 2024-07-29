namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the subject Id: ");
            int subjectId;

            while (!int.TryParse(Console.ReadLine(), out subjectId))
            {
                Console.Write("Please enter a valid number: ");
            }

            Console.Write("Please enter the subject name: ");
            string subjectName = Console.ReadLine()!;

            while (string.IsNullOrEmpty(subjectName))
            {
                Console.Write("Please enter a valid subject name: ");
                subjectName = Console.ReadLine()!;
            }

            Subject subject = new Subject(subjectId, subjectName);

            Console.Clear();
            Console.WriteLine("Please Choose the type of exam\n1- Final Exam\n2- Practical Exam");
            Console.Write("Enter your choice: ");
            int choice;

            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.Write("Please Enter a number: ");
            }

            while (choice != 1 && choice != 2)
            {
                Console.Write("Please enter a value between 1 or 2: ");

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Please enter a valid number: ");
                }
            }

            Console.Write("Please enter the time of the exam (from 30 min to 180 min): ");
            int timeOfExam;
            bool timeCheck = int.TryParse(Console.ReadLine(), out timeOfExam);

            while (!timeCheck || timeOfExam < 30 || timeOfExam > 180)
            {
                if (!timeCheck)
                {
                    Console.Write("Please enter a valid number: ");
                }
                else if (timeOfExam < 30 || timeOfExam > 180)
                {
                    Console.Write("Please enter a value between 30 and 180: ");
                }

                timeCheck = int.TryParse(Console.ReadLine(), out timeOfExam);
            }


            Console.Write("Please Enter the number of Questions: ");
            int numberOfQuestions;

            while (!int.TryParse(Console.ReadLine(), out numberOfQuestions))
            {
                Console.Write("Please Enter a number: ");
            }

            Question[] questions = new Question[numberOfQuestions];
            FinalExam? finalExam = null;
            PracticalExam? practicalExam = null;


            switch (choice)
            {
                case 1:

                    for (int i = 0; i < numberOfQuestions; i++)
                    {

                        Console.Clear();
                        Console.WriteLine("Please Enter Type of Question\n1- MCQ\n2- True or False");
                        Console.Write("Enter your choice: ");

                        int typeChoice;

                        while (!int.TryParse(Console.ReadLine(), out typeChoice))
                        {
                            Console.Write("Please Enter a number: ");
                        }

                        while (typeChoice != 1 && typeChoice != 2)
                        {
                            Console.Write("Please enter a value between 1 or 2: ");

                            while (!int.TryParse(Console.ReadLine(), out typeChoice))
                            {
                                Console.Write("Please enter a valid number: ");
                            }
                        }

                        switch (typeChoice)
                        {
                            case 1:
                                Question mcqQuestionFinal;
                                Console.Clear();
                                Console.WriteLine("MCQ");
                                string questionHeaderFinal = "MCQ";


                                Console.WriteLine("Please Enter Question Body: ");
                                string questionBodyFinal = Console.ReadLine()!;

                                while (string.IsNullOrEmpty(questionBodyFinal))
                                {
                                    Console.WriteLine("Please enter a body for the question");
                                    questionBodyFinal = Console.ReadLine()!;
                                }

                                Console.Write("Please enter the question mark: ");
                                int questionMarkFinal;

                                while (!int.TryParse(Console.ReadLine(), out questionMarkFinal))
                                {
                                    Console.Write("Please Enter a number: ");
                                }

                                Console.WriteLine("Choices of question");
                                Answer[] answersFinal = new Answer[3];
                                string choiceTextFinal;

                                for (int j = 0; j < answersFinal.Length; j++)
                                {
                                    Console.WriteLine($"Please enter choice number {j}: ");
                                    choiceTextFinal = Console.ReadLine()!;

                                    while (string.IsNullOrEmpty(choiceTextFinal))
                                    {
                                        Console.WriteLine("Please enter choice");
                                        choiceTextFinal = Console.ReadLine()!;
                                    }
                                    answersFinal[j] = new Answer(j, choiceTextFinal);
                                }

                                int rightAnswerIdFinal;
                                Console.Write("Please enter the right answer id: ");

                                while (true)
                                {
                                    if (!int.TryParse(Console.ReadLine(), out rightAnswerIdFinal))
                                    {
                                        Console.Write("Please enter a valid number: ");
                                    }
                                    else if (rightAnswerIdFinal < 0 || rightAnswerIdFinal >= answersFinal.Length)
                                    {
                                        Console.Write($"Please enter a valid id between 0 and {answersFinal.Length - 1}: ");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                mcqQuestionFinal = new MCQ(questionHeaderFinal, questionBodyFinal, questionMarkFinal, answersFinal, answersFinal[rightAnswerIdFinal]);
                                questions[i] = mcqQuestionFinal;

                                break;

                            case 2:
                                Question trueOrFalseQuestion;
                                Console.Clear();
                                Console.WriteLine("True or False Question");
                                questionHeaderFinal = "True or False Question";

                                Console.WriteLine("Please Enter Question Body: ");
                                questionBodyFinal = Console.ReadLine()!;

                                while (string.IsNullOrEmpty(questionBodyFinal))
                                {
                                    Console.WriteLine("Please enter a body for the question");
                                    questionBodyFinal = Console.ReadLine()!;
                                }

                                Console.Write("Please enter the question mark: ");

                                while (!int.TryParse(Console.ReadLine(), out questionMarkFinal))
                                {
                                    Console.Write("Please Enter a number: ");
                                }

                                Console.Write("Please enter the right answer id (1 for true and 2 for false): ");

                                while (true)
                                {
                                    if (!int.TryParse(Console.ReadLine(), out rightAnswerIdFinal))
                                    {
                                        Console.Write("Please enter a valid number: ");
                                    }
                                    else if (rightAnswerIdFinal != 1 && rightAnswerIdFinal != 2)
                                    {
                                        Console.Write($"Please enter a valid id between 1 and 2: ");
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                Answer rightAnswer = new Answer(rightAnswerIdFinal, rightAnswerIdFinal == 1 ? "True" : "False");
                                trueOrFalseQuestion = new TrueOrFalseQuestion(questionHeaderFinal, questionBodyFinal, questionMarkFinal, rightAnswer);
                                questions[i] = trueOrFalseQuestion;

                                break;
                        }


                    }

                    finalExam = new FinalExam(timeOfExam, numberOfQuestions, questions);
                    subject.CreateExam(finalExam);
                    break;

                case 2:

                    for (int i = 0; i < numberOfQuestions; i++)
                    {

                        Question mcqQuestion;
                        Console.Clear();
                        Console.WriteLine("MCQ");
                        string questionHeader = "MCQ";


                        Console.WriteLine("Please Enter Question Body: ");
                        string questionBody = Console.ReadLine()!;

                        while (string.IsNullOrEmpty(questionBody))
                        {
                            Console.WriteLine("Please enter a body for the question");
                            questionBody = Console.ReadLine()!;
                        }

                        Console.Write("Please enter the question mark: ");
                        int questionMark;

                        while (!int.TryParse(Console.ReadLine(), out questionMark))
                        {
                            Console.Write("Please Enter a number: ");
                        }

                        Console.WriteLine("Choices of question");
                        Answer[] answers = new Answer[3];
                        string choiceText;

                        for (int j = 0; j < answers.Length; j++)
                        {
                            Console.WriteLine($"Please enter choice number {j}: ");
                            choiceText = Console.ReadLine()!;

                            while (string.IsNullOrEmpty(choiceText))
                            {
                                Console.WriteLine("Please enter choice");
                                choiceText = Console.ReadLine()!;
                            }
                            answers[j] = new Answer(j, choiceText);
                        }

                        int rightAnswerId;
                        Console.Write("Please enter the right answer id: ");

                        while (true)
                        {
                            if (!int.TryParse(Console.ReadLine(), out rightAnswerId))
                            {
                                Console.Write("Please enter a valid number: ");
                            }
                            else if (rightAnswerId < 0 || rightAnswerId >= answers.Length)
                            {
                                Console.Write($"Please enter a valid id between 0 and {answers.Length - 1}: ");
                            }
                            else
                            {
                                break;
                            }
                        }

                        mcqQuestion = new MCQ(questionHeader, questionBody, questionMark, answers, answers[rightAnswerId]);
                        questions[i] = mcqQuestion;

                    }

                    practicalExam = new PracticalExam(timeOfExam, numberOfQuestions, questions);
                    subject.CreateExam(practicalExam);
                    break;

                default:
                    Console.Write("Please Enter a valid input between 1 and 2: ");
                    break;
            }

            Console.Clear();
            string examChoice;
            do
            {
                Console.Write("Do you want to start the exam (Y / N)?: ");
                examChoice = Console.ReadLine()!;

                if (!string.IsNullOrEmpty(examChoice))
                {
                    examChoice = examChoice.ToLower();
                }

                if (string.IsNullOrEmpty(examChoice) || (examChoice != "y" && examChoice != "n"))
                {
                    Console.WriteLine("Please enter a valid choice (Y or N)");
                }

            } while (string.IsNullOrEmpty(examChoice) || (examChoice != "y" && examChoice != "n"));


            if (examChoice == "y")
            {
                if (choice == 1)
                {
                    Console.Clear();
                    Console.WriteLine($"{subject.SubjectName} Exam");
                    Console.WriteLine();
                    finalExam?.ShowExam();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{subject.SubjectName} Exam");
                    Console.WriteLine();
                    practicalExam?.ShowExam();
                }

            }
            else if (examChoice == "n")
            {
                Console.WriteLine("Exam not started.");
            }
        }
    }
}
