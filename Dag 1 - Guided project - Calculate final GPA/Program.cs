string studentName = "Sophia Johnson";
string course1Name = "English 101";
string course2Name = "Algebra 101";
string course3Name = "Biology 101";
string course4Name = "Computer Science I";
string course5Name = "Psychology 101";

int course1Credit = 3;
int course2Credit = 3;
int course3Credit = 4;
int course4Credit = 4;
int course5Credit = 3;
int amountOfCourses = 5;

double sophiaGpa = (course1Credit+course2Credit+course3Credit+course4Credit+course5Credit) / amountOfCourses;

Console.WriteLine("student: " + studentName + " GPA: " + sophiaGpa);
Console.WriteLine("course: " + course1Name + " grade: " + course1Credit);
Console.WriteLine("course: " + course2Name + " grade: " + course2Credit);
Console.WriteLine("course: " + course3Name + " grade: " + course3Credit);
Console.WriteLine("course: " + course4Name + " grade: " + course4Credit);
Console.WriteLine("course: " + course5Name + " grade: " + course5Credit);
