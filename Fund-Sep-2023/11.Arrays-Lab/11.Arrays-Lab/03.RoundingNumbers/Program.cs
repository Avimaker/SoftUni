/*
0.9 1.5 2.4 2.5 3.14

-5.01 -1.599 -2.5 -1.50 0

*/

////input

//string input = Console.ReadLine();

//string[] split = input.Split();

//double[] numbers = new double[split.Length];

//// filling array
//for (int i = 0; i < split.Length; i++)
//{
//numbers[i] = double.Parse(split[i]); 
//}

////print
//for (int i = 0; i < numbers.Length; i++)
//{
//    Console.WriteLine($"{numbers[i]} => {Math.Round(numbers[i], MidpointRounding.AwayFromZero)}");
//}


double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();

int[] roundedNums = new int[nums.Length];

for (int i = 0; i < nums.Length; i++)
{
    roundedNums[i] = (int)Math.Round(nums[i], MidpointRounding.AwayFromZero);
}

//print
for (int i = 0; i < nums.Length; i++)
{
    Console.WriteLine($"{nums[i]} => {roundedNums[i]}");
}