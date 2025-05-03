/* 
This C# console application is designed to:
- Use arrays to store student names and assignment scores.
- Use a `foreach` statement to iterate through the student names as an outer program loop.
- Use an `if` statement within the outer loop to identify the current student name and access that student's assignment scores.
- Use a `foreach` statement within the outer loop to iterate though the assignment scores array and sum the values.
- Use an algorithm within the outer loop to calculate the average exam score for each student.
- Use an `if-elseif-else` construct within the outer loop to evaluate the average exam score and assign a letter grade automatically.
- Integrate extra credit scores when calculating the student's final score and letter grade as follows:
    - detects extra credit assignments based on the number of elements in the student's scores array.
    - divides the values of extra credit assignments by 10 before adding extra credit scores to the sum of exam scores.
- use the following report format to report student grades: 

    Student         Exam Score      Overall Grade   Extra Credit

    Sophia          92.2            95.88   A       3 (3/5*100 = 60 pts)
    Andrew          89.6            91.88   B+      2 (2/5*100 = 40 pts)
    Emma            85.6            89.88   B       4 (4/5*100 = 80 pts)
    Logan           91.2            94.88   A-      2 (2/5*100 = 40 pts)
*/
int examAssignments = 5;

string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };

int[] studentScores = new int[10];

// initialize variables for calculating/storing the sums
int sumAssignmentScores = 0;
int sumExamScores = 0;
int sumExtraCreditScores = 0;

// initialize variables for calculating/storing the averages
decimal currentStudentGrade = 0;
decimal currentExamScore = 0;

// initialize variables for storing extra credit points earned
decimal extraCreditPoints = 0;

string currentStudentLetterGrade = "";

// display the header row for scores/grades
Console.Clear();
// Student         Exam Score      Overall Grade   Extra Credit
Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit\tLetter Grade\n");

/*
The outer foreach loop is used to:
- iterate through student names 
- assign a student's grades to the studentScores array
- sum assignment scores (inner foreach loop)
- calculate numeric and letter grade
- write the score report information
*/
foreach (string name in studentNames)
{
    string currentStudent = name;

    if (currentStudent == "Sophia")
        studentScores = sophiaScores;

    else if (currentStudent == "Andrew")
        studentScores = andrewScores;

    else if (currentStudent == "Emma")
        studentScores = emmaScores;

    else if (currentStudent == "Logan")
        studentScores = loganScores;

    // reset the sum variables for each student
    sumAssignmentScores = 0;
    sumExamScores = 0;
    sumExtraCreditScores = 0;
    int gradedAssignments = 0;
    extraCreditPoints = 0;

    /* 
    the inner foreach loop sums assignment scores
    extra credit assignments are worth 10% of an exam score
    */
    foreach (int score in studentScores)
    {
        gradedAssignments += 1;

        if (gradedAssignments <= examAssignments)
        {
            // add the exam score to the sum
            sumExamScores += score;
        }
        else
        {
            // add the extra credit score to the sum - bonus points equal to 10% of an exam score
            sumExtraCreditScores += score;
        }
    }

    // calculate the exam score average
    currentExamScore = (decimal)sumExamScores / examAssignments;

    // calculate the extra credit points earned
    extraCreditPoints = (decimal)sumExtraCreditScores / examAssignments;

    // calculate the overall grade (including extra credit)
    sumAssignmentScores = sumExamScores + sumExtraCreditScores / 10;
    currentStudentGrade = (decimal)sumAssignmentScores / examAssignments;

    if (currentStudentGrade >= 97)
        currentStudentLetterGrade = "A+";

    else if (currentStudentGrade >= 93)
        currentStudentLetterGrade = "A";

    else if (currentStudentGrade >= 90)
        currentStudentLetterGrade = "A-";

    else if (currentStudentGrade >= 87)
        currentStudentLetterGrade = "B+";

    else if (currentStudentGrade >= 83)
        currentStudentLetterGrade = "B";

    else if (currentStudentGrade >= 80)
        currentStudentLetterGrade = "B-";

    else if (currentStudentGrade >= 77)
        currentStudentLetterGrade = "C+";

    else if (currentStudentGrade >= 73)
        currentStudentLetterGrade = "C";

    else if (currentStudentGrade >= 70)
        currentStudentLetterGrade = "C-";

    else if (currentStudentGrade >= 67)
        currentStudentLetterGrade = "D+";

    else if (currentStudentGrade >= 63)
        currentStudentLetterGrade = "D";

    else if (currentStudentGrade >= 60)
        currentStudentLetterGrade = "D-";

    else
        currentStudentLetterGrade = "F";

    // Student         Exam Score      Overall Grade   Extra Credit

    // Sophia          92.2            95.88   A       3 (3/5*100 = 60 pts)
    Console.WriteLine($"{currentStudent}\t\t{currentExamScore}\t\t{currentStudentGrade}\t\t{extraCreditPoints} ({((decimal)sumExtraCreditScores / (studentScores.Length - examAssignments))/10} pts)\t{currentStudentLetterGrade}");
}

// required for running in VS Code (keeps the Output windows open to view results)
Console.WriteLine("\n\rPress the Enter key to continue");
Console.ReadLine();