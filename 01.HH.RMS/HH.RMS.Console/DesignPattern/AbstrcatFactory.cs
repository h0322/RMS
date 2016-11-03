using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Console.DesignPattern
{
    public class Calculator : AbstrcatFactory
    {
        public Calculator()
        {
            Tax tax = GetInstance().GetTax();
            Bonus bonus = GetInstance().GetBonus();
        }

    }
    public abstract class AbstrcatFactory
    {
        private string factoryName = "ChineseFactory";
        AbstrcatFactory instance = null;
        public AbstrcatFactory GetInstance()
        {

            instance = new ChineseFactory();
            return instance;
        }
        public virtual Tax GetTax()
        {
            return null;
        }
        public virtual Bonus GetBonus()
        {
            return null;
        }
        
    }
    public class Tax
    {}
    public class Bonus
    {}
    public class ChineseFactory : AbstrcatFactory
    {
        public override Tax GetTax()
        {
            return new Tax();
        }
        public override Bonus GetBonus()
        {
            return new Bonus();
        }
    }
    public class AmericanFactory : AbstrcatFactory
    {
        public override Tax GetTax()
        {
            throw new NotImplementedException();
        }
        public override Bonus GetBonus()
        {
            throw new NotImplementedException();
        }
    }
    
}
