using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Console.DesignPattern
{
    public class KFC
    {

        public KFC()
        {
            NormalBuilder builder = new NormalBuilder();
            FoodManager manager = new FoodManager();
            manager.FoodConstruct(builder);
            Food food = builder.GetFood();
            string foodString = food.ShowFood();
            System.Console.Write(foodString);
        }
    }
    public class Food
    {
        public string foodName { get; set; }
        public decimal price { get; set; }
        public List<Food> foodList = new List<Food>();
        public List<Food> AddFood(Food food)
        {
             foodList.Add(food);
             return foodList;
        }
        public string ShowFood()
        {
            string result = "";
            foreach (var food in foodList)
            {
                result += "Name:" + food.foodName + ";Price:" + food.price + "\r\n";
            }
            return result;
        }
 
    }
    public class FoodManager
    {
        public void FoodConstruct(KFCBuilder builder)
        {
            builder.BuildHamb();
            builder.BuildChick();
            builder.BuildCoke();
            builder.BuildChip();
            builder.BuildDanta();
            builder.BuildChick();
        }
    }
    public abstract class KFCBuilder
    {
        public abstract void BuildHamb();
        public abstract void BuildCoke();
        public abstract void BuildChip();
        public abstract void BuildDanta();
        public abstract void BuildChick();
        public abstract Food GetFood();
    }
    public class NormalBuilder:KFCBuilder
    {
        private Food food = new Food();
        public override void BuildHamb()
        {
            food.AddFood(new Food() { foodName = "NormalHamb", price = 10 });
        }
        public override void BuildCoke()
        {
            food.AddFood(new Food() { foodName = "Coke", price = 8 });
        }
        public override void BuildChip()
        {
            food.AddFood(new Food() { foodName = "Chip", price = 6 });
        }
        public override void BuildChick()
        {
            return;
        }
        public override void BuildDanta()
        {
            return;
        }
        public override Food GetFood()
        {
            return food;
        }
    }
    public class GoldBuilder : KFCBuilder
    {
        private Food food = new Food();
        public override void BuildHamb()
        {
            food.AddFood(new Food() { foodName = "GoldHamb", price = 16 });
        }
        public override void BuildCoke()
        {
            food.AddFood(new Food() { foodName = "Coke", price = 10 });
        }
        public override void BuildChip()
        {
            food.AddFood(new Food() { foodName = "Chip", price = 8 });
        }
        public override void BuildChick()
        {
            food.AddFood(new Food() { foodName = "Chick", price = 12 });
        }
        public override void BuildDanta()
        {
            food.AddFood(new Food() { foodName = "Chick", price = 4 });
        }
        public override Food GetFood()
        {
            return food;
        }
    }
}
