using System;

class Program
{
    static void Main(string[] args)
    {
        // Scores arrays with extra credit scores added at the end
        int[] sophiaScores = new int[] { 90, 86, 87, 98, 100, 94, 90 };
        int[] andrewScores = new int[] { 92, 89, 81, 96, 90, 89 };
        int[] emmaScores = new int[] { 90, 85, 87, 98, 68, 89, 89, 89 };
        int[] loganScores = new int[] { 90, 95, 87, 88, 96, 96 };

        // Student names
        string[] studentNames = new string[] { "Sophia", "Andrew", "Emma", "Logan" };
        
        // Write the Report Header to the console with aligned columns
        Console.WriteLine("{0,-10} {1,-7} {2,-15}", "Student", "Grade", "Letter Grade");
        
        // Loop through each student
        foreach (string name in studentNames)
        {
            int[] studentScores;

            // Assign scores array based on current student
            switch (name)
            {
                case "Sophia": studentScores = sophiaScores; break;
                case "Andrew": studentScores = andrewScores; break;
                case "Emma": studentScores = emmaScores; break;
                case "Logan": studentScores = loganScores; break;
                default: continue; // Skip if student is not found
            }

            // Initialize/reset the sum of scored assignments
            int sumAssignmentScores = 0;
            decimal currentStudentGrade = 0;
            int examAssignments = 5;

            // Loop through the scores array and calculate the grade for the student
            int gradedAssignments = 0;
            foreach (int score in studentScores)
            {
                gradedAssignments += 1;

                if (gradedAssignments <= examAssignments)
                    sumAssignmentScores += score; // Add the exam score to the sum
                else
                    sumAssignmentScores += score / 10; // Add the extra credit points to the sum
            }

            // Calculate the final numeric grade (sum divided by number of exams)
            currentStudentGrade = (decimal)sumAssignmentScores / examAssignments;

            // Determine the letter grade based on numeric grade
            string currentStudentLetterGrade = currentStudentGrade >= 97 ? "A+" :
                                              currentStudentGrade >= 93 ? "A" :
                                              currentStudentGrade >= 90 ? "A-" :
                                              currentStudentGrade >= 87 ? "B+" :
                                              currentStudentGrade >= 83 ? "B" :
                                              currentStudentGrade >= 80 ? "B-" :
                                              currentStudentGrade >= 77 ? "C+" :
                                              currentStudentGrade >= 73 ? "C" :
                                              currentStudentGrade >= 70 ? "C-" :
                                              currentStudentGrade >= 67 ? "D+" :
                                              currentStudentGrade >= 63 ? "D" :
                                              currentStudentGrade >= 60 ? "D-" : "F";

            // Output the student's name, numeric grade, and letter grade with formatted columns
            Console.WriteLine("{0,-10} {1,-7:F1} {2,-15}", name, currentStudentGrade, currentStudentLetterGrade);
        }

        // Keep the window open to view results
        Console.WriteLine("\nPress the Enter key to continue");
        Console.ReadLine();
    }
}
