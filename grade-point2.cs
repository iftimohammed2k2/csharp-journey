using System;

class Program
{
    static void Main()
    {
        string[] studentNames = { "Sophia", "Andrew", "Emma", "Logan" };

        int[][] studentScores = {
            new int[] { 90, 86, 87, 98, 100 }, // Sophia
            new int[] { 92, 89, 81, 96, 90 },  // Andrew
            new int[] { 90, 85, 87, 93, 88 },  // Emma
            new int[] { 94, 92, 91, 96, 98 }   // Logan
        };

        Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit");

        for (int i = 0; i < studentNames.Length; i++)
        {
            string name = studentNames[i];
            int[] scores = studentScores[i];

            int examSum = 0;
            for (int j = 0; j < 4; j++)
                examSum += scores[j];

            int extra = scores[4];

            decimal examAvg = (decimal)examSum / 4;
            decimal extraPoints = (decimal)extra * 0.10m;
            decimal finalScore = (examSum + extraPoints) / 4;
            decimal extraPerExam = extraPoints / 4;

            string letterGrade =
                finalScore >= 93 ? "A" :
                finalScore >= 90 ? "A-" :
                finalScore >= 87 ? "B+" :
                finalScore >= 83 ? "B" :
                finalScore >= 80 ? "B-" : "C";

            Console.WriteLine($"{name,-15}{examAvg,6:F1}\t\t{finalScore,6:F2}\t{letterGrade,-2}\t{extra} ({extraPerExam:F2} pts)");
        }
    }
}
