using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH.RMS.Console.DesignPattern
{
    public abstract class Handler
    {
        private int days = 0;
        public Handler nextHandler;
        public void HandlerRequest(int requestDay)
        {
            if (IsResposibility(requestDay))
            {
                Sign();
                return;
            }
            if (nextHandler == null)
            {
                return;
            }
            nextHandler.HandlerRequest(requestDay);
        }
        public void SetNext(Handler handler)
        {
            this.nextHandler = handler;
        }
        public abstract bool IsResposibility(int days);
        public abstract void Sign(); 
    }

    public class Leader : Handler
    {
        public override bool IsResposibility(int days)
        {
            if (days <= 1)
            {
                return true;
            }
            return false;
        }
        public override void Sign()
        {
            System.Console.Write("Leader Signer");
        }
    }
    public class Master : Handler
    {
        public override bool IsResposibility(int days)
        {
            if (days > 1 && days <= 3)
            {
                return true;
            }
            return false;
        }
        public override void Sign()
        {
            System.Console.Write("Master Signer");
        }
    }
    public class CEO : Handler
    {
        public override bool IsResposibility(int days)
        {
            if (days > 3)
            {
                return true;
            }
            return false;
        }
        public override void Sign()
        {
            System.Console.Write("CEO Signer");
        }
    }
    public class ResposibilityMain 
    {
        public ResposibilityMain()
        {
            Leader leader = new Leader();
            Master master = new Master();
            CEO ceo = new CEO();
            leader.SetNext(master);
            master.SetNext(ceo);

            leader.HandlerRequest(4);
        }


    }
}
