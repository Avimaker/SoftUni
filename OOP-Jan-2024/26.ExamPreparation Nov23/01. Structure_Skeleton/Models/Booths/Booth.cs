using System;
using System.Text;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int capacity;
        // извикваме си репозиторитата и ги инстанцираме в конструктора
        private DelicacyRepository delicacy;
        private CocktailRepository cocktail;

        public Booth(int boothId, int capacity)
        {
            BoothId = boothId;
            Capacity = capacity;
            CurrentBill = 0;
            Turnover = 0;
            IsReserved = false;
            delicacy = new DelicacyRepository();
            cocktail = new CocktailRepository();
        }

        public int BoothId { get; private set; }

        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                this.capacity = value;
            }
        }

        //така private set идва по дефолт !!!
        //public IRepository<IDelicacy> DelicacyMenu => delicacy;
        // така е по подрпбно
        public IRepository<IDelicacy> DelicacyMenu
        {
            get { return this.delicacy; }
            private set { }
        }

        // Todo
        public IRepository<ICocktail> CocktailMenu => cocktail;


        public double CurrentBill { get; private set; }

        public double Turnover { get; private set; }

        public bool IsReserved { get; private set; }


        public void ChangeStatus()
        {
            if (IsReserved == true)
            {
                IsReserved = false;
            }
            else
            {
                IsReserved = true;
            }
        }

        public void Charge()
        {
            Turnover += CurrentBill;
            CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            CurrentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {BoothId}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Turnover: {Turnover:F2} lv");
            sb.AppendLine($"-Cocktail menu:");

            foreach (var cocktail in cocktail.Models)//CocktailMenu.Models
            {
                sb.AppendLine($"--{cocktail.ToString()}");//вика overide  на tostring от cocktails
            }

            sb.AppendLine($"-Delicacy menu:");

            foreach (var delicacy in delicacy.Models)//моделс заради пропъртито от репозиторито за да може да ми върне колекцията
            {
                sb.AppendLine($"--{delicacy.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}

