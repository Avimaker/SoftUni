using System.Reflection;
using System.Text;

namespace MailClient
{
    public class MailBox
    {

        private int capacity;
        private List<Mail> inbox;
        private List<Mail> archive;

        public MailBox(int capacity)
        {
            Capacity = capacity;
            inbox = new List<Mail>();
            archive = new List<Mail>();
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public List<Mail> Inbox
        {
            get { return this.inbox; }
            private set { this.inbox = value; }
        }

        public List<Mail> Archive
        {
            get { return this.archive; }
            private set { this.archive = value; }
        }

        public void IncomingMail(Mail mail)
        {
            if (inbox.Count < capacity)
            {
                inbox.Add(mail);
            }
        }

        public bool DeleteMail(string sender)
        {
            bool isFound = false;
            if ((inbox.FirstOrDefault(s => s.Sender == sender)) != null)
            {
                inbox.Remove(inbox.FirstOrDefault(s => s.Sender == sender));
                isFound = true;
            }

            return isFound;

            ////друг начин
            //Mail mail = inbox.FirstOrDefault(s => s.Sender == sender);
            //if (mail == null)
            //{
            //    return false;
            //}

            //return Inbox.Remove(mail);

        }

        public int ArchiveInboxMessages()
        {
            int mailsMoved = inbox.Count;

            Archive.AddRange(inbox); //добавяме всички мейли
            Inbox = new List<Mail>(); //инициализираме инбокса

            return mailsMoved;
        }

        public string GetLongestMessage()
        {
            //така намираме най-дългото боди на мейл, сортираме по боди и взимаме първото
            Mail longestMail = inbox.OrderByDescending(m => m.Body).First(); 

            return longestMail.ToString();
        }

        public string InboxView()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Inbox:");

            foreach (var mail in inbox)
            {
                sb.AppendLine(mail.ToString());
            }

            return sb.ToString().TrimEnd();
        }

    }
}
