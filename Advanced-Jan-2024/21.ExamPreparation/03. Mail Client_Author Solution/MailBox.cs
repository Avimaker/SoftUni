using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public int Capacity { get; set; }

        public List<Mail> Inbox { get; set; }

        public List<Mail> Archive { get; set; }


        public void IncomingMail(Mail mail)
        {
            if (Inbox.Count < Capacity) 
            {
                Inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
            => Inbox.Remove(Inbox.FirstOrDefault(m => m.Sender == sender));

        public int ArchiveInboxMessages()
        {
            int count = Inbox.Count;
            Archive.AddRange(Inbox);
            Inbox = new List<Mail>();

            return count;
        }

        public string GetLongestMessage()
            => Inbox.OrderByDescending(m => m.Body.Length).FirstOrDefault().ToString();

        public string InboxView()
        {
            StringBuilder sb = new ();
            sb.AppendLine("Inbox:");

            foreach (Mail mail in Inbox)
            {
                sb.AppendLine(mail.ToString().TrimEnd());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
