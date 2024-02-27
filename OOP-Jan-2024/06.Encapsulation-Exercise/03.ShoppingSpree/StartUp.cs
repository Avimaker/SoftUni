/*
Peter=-11;George=4
Bread=10;Milk=2;
Peter Bread
George Milk
George Milk
Peter Milk
END
 
*/

using ShoppingSpree.Models;

namespace ShoppingSpree;
public class StartUp
{
    static void Main(string[] args)
    {
        List<Person> persons = new();
        List<Product> products = new();

        try
        {

            string[] inputPersons = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < inputPersons.Length; i++)
            {
                string[] tempPerson = inputPersons[i].Split("=");

                Person person = new(tempPerson[0], decimal.Parse(tempPerson[1]));

                persons.Add(person);
            }

            string[] inputProducts = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            for (int i = 0; i < inputProducts.Length; i++)
            {
                string[] tempProduct = inputProducts[i].Split("=");

                Product product = new(tempProduct[0], decimal.Parse(tempProduct[1]));

                products.Add(product);
            }

        }

        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);

            return;
        }


        string command = default;
        while ((command = Console.ReadLine()) != "END")
        {
            string[] arguments = command.Split();
            string name = arguments[0];
            string product = arguments[1];

            Person searchedName = persons.FirstOrDefault(p => p.Name == name);
            Product searchedProduct = products.FirstOrDefault(p => p.Name == product);

            if (searchedName is not null && searchedProduct is not null)
            {
                Console.WriteLine(searchedName.Add(searchedProduct));
            }
        }

        Console.WriteLine(string.Join(Environment.NewLine, persons));
    }
}

