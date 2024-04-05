using System;
using System.Linq;
using System.Text;
using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository booths;


        public Controller()
        {
            booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            var booth = new Booth(booths.Models.Count + 1, capacity);
            booths.AddModel(booth);

            return $"Added booth number {booth.BoothId} with capacity {capacity} in the pastry shop!";
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            if (cocktailTypeName != "Hibernation" && cocktailTypeName != "MulledWine")
            {
                return $"Cocktail type {cocktailTypeName} is not supported in our application!";
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return $"{size} is not recognized as valid cocktail size!";
            }

            IBooth booth = booths.Models.FirstOrDefault(i => i.BoothId == boothId);
            ICocktail coctail = booth.CocktailMenu.Models.FirstOrDefault(n => n.Name == cocktailName && n.Size == size);

            if (coctail != null)
            {
                return $"{size} {cocktailName} is already added in the pastry shop!";
            }

            if (cocktailTypeName == "Hibernation")
            {
                coctail = new Hibernation(cocktailName, size);
            }
            else if (cocktailTypeName == "MulledWine")
            {
                coctail = new MulledWine(cocktailName, size);
            }

            booth.CocktailMenu.AddModel(coctail);

            return $"{size} {cocktailName} {cocktailTypeName} added to the pastry shop!";

        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            if (delicacyTypeName != "Stolen" && delicacyTypeName != "Gingerbread")
            {
                return $"Delicacy type {delicacyTypeName} is not supported in our application!";
            }

            var booth = booths.Models.FirstOrDefault(i => i.BoothId == boothId);
            var delicasy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName);

            if (delicasy != null)
            {
                return $"{delicacyName} is already added in the pastry shop!";
            }

            if (delicacyTypeName == "Stolen")
            {
                delicasy = new Stolen(delicacyName);
            }
            else if (delicacyTypeName == "Gingerbread")
            {
                delicasy = new Gingerbread(delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicasy);

            return $"{delicacyTypeName} {delicacyName} added to the pastry shop!";
        }

        public string BoothReport(int boothId)
        {
            var booth = booths.Models.First(b => b.BoothId == boothId);
            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {booth.CurrentBill:f2} lv");
            sb.AppendLine($"Booth {boothId} is now available!");

            booth.Charge();
            booth.ChangeStatus();
   
            return sb.ToString().TrimEnd();
        }

        public string ReserveBooth(int countOfPeople)
        {
            var booth = booths.Models
                .Where(b => !b.IsReserved && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .FirstOrDefault();

            if (booth == null)
            {
                return $"No available booth for {countOfPeople} people!";
            }

            booth.ChangeStatus();

            return $"Booth {booth.BoothId} has been reserved for {countOfPeople} people!";
        }

        public string TryOrder(int boothId, string order)
        {

            var booth = booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            var cmdArg = order.Split('/');
            var itemTypeName = cmdArg[0];
            var itemName = cmdArg[1];
            var count = int.Parse(cmdArg[2]);
            var size = string.Empty;

            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                size = cmdArg[3];
            }

            if (itemTypeName != "Hibernation" && itemTypeName != "MulledWine" && itemTypeName != "Gingerbread" && itemTypeName != "Stolen")
            {
                return $"{itemTypeName} is not recognized type!";
            }

            if (itemTypeName == "Hibernation" || itemTypeName == "MulledWine")
            {
                if (!booth.CocktailMenu.Models.Any(c => c.Name == itemName))
                {
                    return $"There is no {itemTypeName} {itemName} available!";
                }

                var cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == itemName && c.Size == size);
                        
                if (cocktail == null)
                {
                    return $"There is no {size} {itemName} available!";
                }

                booth.UpdateCurrentBill(count * cocktail.Price);

                return $"Booth {boothId} ordered {count} {itemName}!";
            }
            else
            {
                if (!booth.DelicacyMenu.Models.Any(c => c.Name == itemName))
                {
                    return $"There is no {itemTypeName} {itemName} available!";
                }

                var delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == itemName);

                if (delicacy == null)
                {
                    return $"There is no {itemTypeName} {itemName} available!";
                }

                booth.UpdateCurrentBill(count * delicacy.Price);

                return $"Booth {boothId} ordered {count} {itemName}!";

            }

        }
    }
}

