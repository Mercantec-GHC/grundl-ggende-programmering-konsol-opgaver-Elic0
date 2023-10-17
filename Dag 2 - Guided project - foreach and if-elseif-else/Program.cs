using System;

int currentAssignments = 5;

int sophia1 = 90;
int sophia2 = 86;
int sophia3 = 87;
int sophia4 = 98;
int sophia5 = 100;

int andrew1 = 92;
int andrew2 = 89;
int andrew3 = 81;
int andrew4 = 96;
int andrew5 = 90;

int emma1 = 90;
int emma2 = 85;
int emma3 = 87;
int emma4 = 98;
int emma5 = 68;

int logan1 = 90;
int logan2 = 95;
int logan3 = 87;
int logan4 = 88;
int logan5 = 96;

decimal sophiaTotalScore = 0;
decimal andrewTotalScore = 0;
decimal emmaTotalScore = 0;
decimal loganTotalScore = 0;

decimal classTotalScore = 0;

decimal sophiaAverage, andrewAverage, emmaAverage, loganAverage;

sophiaTotalScore = CalculateTotalScore(sophia1, sophia2, sophia3, sophia4, sophia5);
andrewTotalScore = CalculateTotalScore(andrew1, andrew2, andrew3, andrew4, andrew5);
emmaTotalScore = CalculateTotalScore(emma1, emma2, emma3, emma4, emma5);
loganTotalScore = CalculateTotalScore(logan1, logan2, logan3, logan4, logan5);

sophiaAverage = CalculateAverage(sophiaTotalScore, currentAssignments);
andrewAverage = CalculateAverage(andrewTotalScore, currentAssignments);
emmaAverage = CalculateAverage(emmaTotalScore, currentAssignments);
loganAverage = CalculateAverage(loganTotalScore, currentAssignments);

classTotalScore = sophiaAverage + andrewAverage + emmaAverage + loganAverage;

decimal CalculateTotalScore(params int[] scores)
{
    decimal total = 0;
    foreach (int score in scores)
    {
        total += (score <= 100) ? score : 100; // Cap scores at 100
    }
    return total;
}

decimal CalculateAverage(decimal total, int assignments)
{
    return total / assignments;
}

string GetLetterGrade(decimal grade)
{
    if (grade >= 97)
        return "A+";
    else if (grade >= 93)
        return "A";
    else if (grade >= 90)
        return "A-";
    else if (grade >= 87)
        return "B+";
    else if (grade >= 83)
        return "B";
    else if (grade >= 80)
        return "B-";
    else if (grade >= 77)
        return "C+";
    else if (grade >= 73)
        return "C";
    else if (grade >= 70)
        return "C-";
    else if (grade >= 67)
        return "D+";
    else if (grade >= 63)
        return "D";
    else if (grade >= 60)
        return "D-";
    else
        return "F";
}

Console.WriteLine("Student\t\tGrade\tLetter Grade\n");
Console.WriteLine("Sophia:\t\t" + sophiaAverage + "\t" + GetLetterGrade(sophiaAverage));
Console.WriteLine("Andrew:\t\t" + andrewAverage + "\t" + GetLetterGrade(andrewAverage));
Console.WriteLine("Emma:\t\t" + emmaAverage + "\t" + GetLetterGrade(emmaAverage));
Console.WriteLine("Logan:\t\t" + loganAverage + "\t" + GetLetterGrade(loganAverage));

// Calculate the class average
decimal classAverage = classTotalScore / 4;
Console.WriteLine($"\nClass Average: {classAverage:F1}");

Console.WriteLine("Press the Enter key to continue");
Console.ReadLine();