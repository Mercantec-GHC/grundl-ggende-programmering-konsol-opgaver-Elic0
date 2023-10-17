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

    Student         Grade

    Sophia:         92.2    A-
    Andrew:         89.6    B+
    Emma:           85.6    B
    Logan:          91.2    A-
*/
using System;
using System.Collections.Generic;

int examAssignments = 5;
int studentAmount = 4;

string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };

Dictionary<string, int[]> studentScoresDict = new Dictionary<string, int[]>
{
    { "Sophia", new int[] { 90, 86, 87, 98, 100, 94, 90 } },
    { "Andrew", new int[] { 92, 89, 81, 96, 90, 89 } },
    { "Emma", new int[] { 90, 85, 87, 98, 68, 89, 89, 89 } },
    { "Logan", new int[] { 90, 95, 87, 88, 96, 96 } }
};

// display the header row for scores/grades
Console.Clear();
Console.WriteLine("Student\t\tGrade\tLetter Grade\n");

decimal classScores = 0;



foreach (string name in studentNames)
{
    if (studentScoresDict.TryGetValue(name, out int[] studentScores))
    {
        decimal currentStudentGrade = CalculateAverageGrade(studentScores, examAssignments);
        string currentStudentLetterGrade = GetLetterGrade(currentStudentGrade);

        Console.WriteLine($"{name}\t\t{currentStudentGrade:F1}\t{currentStudentLetterGrade}");
        classScores += currentStudentGrade;
    }
}

static decimal CalculateAverageGrade(int[] scores, int examAssignments)
{
    int sumAssignmentScores = 0;
    int extraCreditScores = 0;

    for (int i = 0; i < scores.Length; i++)
    {
        if (i < examAssignments)
            sumAssignmentScores += scores[i];
        else
            extraCreditScores += scores[i];
    }

    sumAssignmentScores += (extraCreditScores / 10);

    return (decimal)sumAssignmentScores / examAssignments;
}

static string GetLetterGrade(decimal grade)
{
    switch (grade)
    {
        case var g when g >= 97:
            return "A+";
        case var g when g >= 93:
            return "A";
        case var g when g >= 90:
            return "A-";
        case var g when g >= 87:
            return "B+";
        case var g when g >= 83:
            return "B";
        case var g when g >= 80:
            return "B-";
        case var g when g >= 77:
            return "C+";
        case var g when g >= 73:
            return "C";
        case var g when g >= 70:
            return "C-";
        case var g when g >= 67:
            return "D+";
        case var g when g >= 63:
            return "D";
        case var g when g >= 60:
            return "D-";
        default:
            return "F";
    }
}
decimal classAverage = classScores / studentAmount;
Console.WriteLine($"\nClass Average: {classAverage:F1}");

Console.WriteLine("\n\rPress the Enter key to continue");
Console.ReadLine();
