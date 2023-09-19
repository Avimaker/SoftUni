using System; 

namespace _04.Workout 
{ 
    class Program 
    { 
        static void Main(string[] args) 
        { 
            int days = int.Parse(Console.ReadLine()); 
            double firstlKm = double.Parse(Console.ReadLine()); 

            double totalKm = 0 + firstlKm; 
            double daylyKm = 0 + firstlKm; 
            int goal = 1000; 
            bool isTrue = false; 

            for (int i = 1; i <= days || totalKm >= goal; i++) 
            { 
                int procent = int.Parse(Console.ReadLine()); 

                daylyKm = daylyKm + (daylyKm * procent * 0.01); 
                totalKm += daylyKm; 
                if (totalKm >= goal) 
                { 
                    isTrue = true; 
                    break; 
                } 
            } 

            if (isTrue) 
            { 
                Console.WriteLine($"You've done a great job running {Math.Ceiling(totalKm - goal)} more kilometers!"); 
            } 
            else 
            { 
                Console.WriteLine($"Sorry Mrs. Ivanova, you need to run {Math.Ceiling(goal - totalKm)} more kilometers"); 

            } 

        } 
    } 
} 


