/*
Chat Hello
Chat darling
Edit darling Darling
Spam how are you
Delete Darling
end

Chat Hello
Delete John
Pin Hi
end

Chat John
Spam Let's go to the zoo
Edit zoo cinema
Chat tonight
Pin John
end
 
*/

namespace _03.Problem3;

class Program
{
    static void Main(string[] args)
    {
        List<string> chatHistory = new List<string>();


        string command = default;
        while ((command = Console.ReadLine()) != "end")
        {
            string[] arguments = command.Split();
            string action = arguments[0];

            if (arguments[0] == "Chat")
            {
                chatHistory.Add(arguments[1]);
            }
            else if (arguments[0] == "Delete")
            {
                string messageToDelete = arguments[1];
                chatHistory.RemoveAll(message => message == messageToDelete);
            }
            else if (arguments[0] == "Edit")
            {
                string messageToEdit = arguments[1];
                string editedMessage = arguments[2];
                int indexToEdit = chatHistory.IndexOf(messageToEdit);
                if (indexToEdit >= 0 && indexToEdit < chatHistory.Count)
                {
                    chatHistory[indexToEdit] = editedMessage;
                }
            }
            else if (arguments[0] == "Pin")
            {
                string messageToPin = arguments[1];
                bool ifExixst = chatHistory.Contains(arguments[1]);

                if (ifExixst)
                {
                    chatHistory.Remove(messageToPin);
                    chatHistory.Add(messageToPin);
                }
            }
            else if (arguments[0] == "Spam")
            {
                for (int i = 1; i < arguments.Length; i++)
                {
                    chatHistory.Add(arguments[i]);
                }
            }


        }


        foreach (string message in chatHistory)
        {
            Console.WriteLine(message);
        }


    }
}
