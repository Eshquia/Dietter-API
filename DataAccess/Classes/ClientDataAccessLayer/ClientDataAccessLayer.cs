using DataAccess.DataCast;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Classes.ClientDataAccesLayer
{
    public class ClientDataAccessLayer : IClientDataAccessLayer
    {
        private DietterContext db = new DietterContext();

        public bool DeleteClient(int id)
        {
            var result = db.Clients.First(x => x.ClientId == id);
            if (result != null)
            {
                result.Isdeleted = true;
                db.Clients.Update(result);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public ClientDto GetClient(int id)
        {
            var client = db.Clients
                              .Where(x => x.ClientId == id)
                              .Select(x => new ClientDto { ClientName = x.ClientName, ClientId = x.ClientId })
                              .FirstOrDefault();
            return client;
        }

        public List<ClientDto> GetClientList()
        {
            var list = (from client in db.Clients.Where(x => x.Isdeleted != true)
                        select new ClientDto { ClientName = client.ClientName.Trim(), ClientId = client.ClientId }).ToList();

            return list;
        }

        public bool PostClient(ClientDto client)
        {
            var newClient = new Clients();
            newClient.ClientName = client.ClientName;
            newClient.ClientId = client.ClientId;
            db.Clients.Add(newClient);
            db.SaveChanges();
            return true;
        }

        public bool PutClient(ClientDto client)
        {
            var result = db.Clients.First(x => x.ClientId == client.ClientId);
            result.ClientName = client.ClientName;
            db.Clients.Update(result);
            db.SaveChanges();
            return true;
        }

        public List<List<DietList>> CreateDiet(Diet diet)
        {
            var mainFoodCount = diet.ThatDay - diet.Snacks;
            var randListId = new Random();
            var id = randListId.Next(99999999);
            var breakfast = db.Foods.Where(food => food.FoodType == 1).ToList();
            var snacksFood = db.Foods.Where(food => food.FoodType == 2).ToList();
            var dinner = db.Foods.Where(food => food.FoodType == 3).ToList();
            var lunches = db.Foods.Where(food => food.FoodType == 4).ToList();

            var assignedList = db.AssignedList.Where(x => x.ClientId == diet.ClientId);
            var newList = new Lists();
            newList.Id = id;
            newList.ListId = id;
            var toBeAssigned = new List<AssignedList>();
            var totalCalorie = 0;




                    for (int i = 0; i < 7; i++)
                    {
                        var newbreakfast = new AssignedList();
                        newbreakfast.ClientId = diet.ClientId;
                        newbreakfast.Date = i;
                        newbreakfast.FoodId = getRandomFood(1);
                        newbreakfast.ListId = id;
                        newbreakfast.Id = getRandomNumber();
                        toBeAssigned.Add(newbreakfast);

                        var newdinner = new AssignedList();
                        newdinner.ClientId = diet.ClientId;
                        newdinner.Date = i;
                        newdinner.ListId = id;
                        newdinner.Id = getRandomNumber();
                        newdinner.FoodId = getRandomFood(3);
                        toBeAssigned.Add(newdinner);

                        var newlunches = new AssignedList();
                        newlunches.ClientId = diet.ClientId;
                        newlunches.Date = i;
                        newlunches.ListId = id;
                        newlunches.Id = getRandomNumber();
                        newlunches.FoodId = getRandomFood(4);
                        toBeAssigned.Add(newlunches);

                        for (int snacks = 0; snacks < diet.Snacks; snacks++)
                        {
                            var newsnacks = new AssignedList();
                            newsnacks.ClientId = diet.ClientId;
                            newsnacks.Date = i;
                            newsnacks.ListId = id;
                            newsnacks.Id = getRandomNumber();
                            newsnacks.FoodId = getRandomFood(2);
                            toBeAssigned.Add(newsnacks);
                        }

                    }

                    newList.ClientId = diet.ClientId;
                    db.Lists.Add(newList);
                    db.SaveChanges();
                    db.AssignedList.AddRange(toBeAssigned);
                    db.SaveChanges();

                

            
            return handleList(toBeAssigned);
        }

        public int getRandomFood(int foodType)
        {
            var rand = new Random();
            var foods = db.Foods.Where(food => food.FoodType == foodType).ToArray();
            if (foods.Count() == 0)
            {
                return 0;
            }
            return foods[rand.Next(foods.Count() - 1)].Id; ;
        }

        public int getRandomNumber()
        {
            var rand = new Random();
            var id = rand.Next(9999999);
            return id;
        }

        public List<List<DietList>> handleList(List<AssignedList> list)
        {
            var handledList = new List<DietList>();
            var foodList = db.Foods.ToList();

            var groupedDietList = list
            .GroupBy(u => u.Date)
            .Select(grp => grp.ToList())
            .ToList();


            foreach (var item in list)
            {
                var entry = new DietList();
                entry.DateNo = getDateNo(item.Date);
                entry.FoodName = foodList.FirstOrDefault(food => food.Id == item.FoodId).FoodName;
                handledList.Add(entry);
            }

           var groupList= handledList
            .GroupBy(u => u.DateNo)
            .Select(grp => grp.ToList())
            .ToList();
            return groupList;
        }

        public string getDateNo(int no)
        {
            string[] Days = { "Pazartesi", "Salı", "Çarşamba", "Perşembe","Cuma","Cumartesi","Pazar" };
            return Days[no];
        }


    }
}
